using System.IO.Abstractions;
using System.Text;
using System.Text.RegularExpressions;
using Dapper;
using DB.GraphQL.Postgres.Helpers;
using DB.GraphQL.Postgres.Services;

namespace DB.GraphQL.Postgres.Schema;

public class Mutation
{
    private readonly IConnectionFactory _factory;
    private readonly Query _query;

    public Mutation(IConnectionFactory factory, Query query)
    {
        _factory = factory;
        _query = query;
    }
    
    public async Task<AddTablePayload> AddTable(AddTableInput input)
    {
        if (!NameValidator.IsValid(input.Name))
        {
            return new AddTablePayload("Invalid table name");
        }
        
        var queryBuilder = new StringBuilder($"CREATE TABLE IF NOT EXISTS \"{input.Name}\" (");
        queryBuilder.Append($"\"$id\" SERIAL PRIMARY KEY");

        foreach (var column in input.Columns)
        {
            if (!NameValidator.IsValid(column.Name))
            {
                return new AddTablePayload($"Invalid column name ${column.Name}");
            }
            
            switch (column.Type)
            {
                case ColumnType.String:
                    queryBuilder.Append($", \"{column.Name}\" TEXT NOT NULL DEFAULT ''");
                    break;
                case ColumnType.Integer:
                    queryBuilder.Append($", \"{column.Name}\" INTEGER NOT NULL DEFAULT 0");
                    break;
                case ColumnType.Real:
                    queryBuilder.Append($", \"{column.Name}\" DOUBLE PRECISION NOT NULL DEFAULT 0");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        queryBuilder.Append(");");

        await using var connection = _factory.Create();
        await connection.OpenAsync();
        await using var transaction = await connection.BeginTransactionAsync();

        await connection.ExecuteAsync(queryBuilder.ToString());
        await connection.ExecuteAsync("INSERT INTO \"tables\" (\"name\") VALUES (@Name);", new { Name = input.Name });
        await transaction.CommitAsync();

        return new AddTablePayload(input.Name);
    }
    
    public async Task<bool> RemoveTable(string tableName)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        await using var transaction = await connection.BeginTransactionAsync();
        
        await connection.ExecuteAsync($"DROP TABLE IF EXISTS \"{tableName}\";");
        await connection.ExecuteAsync("DELETE FROM \"tables\" WHERE \"name\" = @Name;", new { Name = tableName });
        await transaction.CommitAsync();
        
        return true;
    }
    
    public async Task<bool> AddRow(string tableName, IEnumerable<CellInput> row)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        var queryBuilder = new StringBuilder($"insert into \"{tableName}\" (");

        var cellInputs = row as CellInput[] ?? row.ToArray();
        
        foreach (var col in cellInputs.Select(x => x.ColumnName))
        {
            if (!NameValidator.IsValid(col))
            {
                throw new ArgumentException("Invalid column name", nameof(col));
            }
            
            queryBuilder.Append($"\"{col}\", ");
        }
        
        queryBuilder.Remove(queryBuilder.Length - 2, 2);
        queryBuilder.Append(") values (");

        var parameters = new DynamicParameters();
        foreach (var cell in cellInputs)
        {
            queryBuilder.Append($"@{cell.ColumnName},");
            object? value = (object?)cell.Value.String ?? cell.Value.Real ?? cell.Value.Int;
            parameters.Add(cell.ColumnName, value);
        }
        
        queryBuilder.Remove(queryBuilder.Length - 1, 1);
        queryBuilder.Append(");");
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        
        await connection.ExecuteAsync(queryBuilder.ToString(), parameters);
        
        return true;
    }
    
    public async Task<bool> RemoveRow(string tableName, int id)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        
        await connection.ExecuteAsync($"DELETE FROM \"{tableName}\" WHERE \"$id\" = @Id;", new { Id = id });
        
        return true;
    }
    
    public async Task<bool> UpdateRow(string tableName, int id, IEnumerable<CellInput> row)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        var queryBuilder = new StringBuilder($"update \"{tableName}\" set ");
        var parameters = new DynamicParameters();
        
        foreach (var cell in row)
        {
            if (!NameValidator.IsValid(cell.ColumnName))
            {
                throw new ArgumentException("Invalid column name", nameof(cell.ColumnName));
            }
            
            queryBuilder.Append($"\"{cell.ColumnName}\" = @{cell.ColumnName}, ");
            
            object? value = (object?)cell.Value.String ?? cell.Value.Real ?? cell.Value.Int;
            parameters.Add(cell.ColumnName, value);
        }
        
        queryBuilder.Remove(queryBuilder.Length - 2, 2);
        queryBuilder.Append($" where \"$id\" = @Id;");
        parameters.Add("Id", id);
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        
        await connection.ExecuteAsync(queryBuilder.ToString(), parameters);
        
        return true;
    }
}

public record AddTableInput(string Name, IEnumerable<ColumnInput> Columns);
public record ColumnInput(string Name, ColumnType Type);
public record AddTablePayload(string Name);

public class CellInput
{
    public string ColumnName { get; set; }
    
    public CellData Value { get; set; }

}

[OneOf]
public class CellData
{
    public int? Int { get; set; }
    public double? Real { get; set; }
    public string? String { get; set; }
}
