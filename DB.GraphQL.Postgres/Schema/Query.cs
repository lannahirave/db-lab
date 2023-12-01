using Dapper;
using DB.GraphQL.Postgres.Helpers;
using DB.GraphQL.Postgres.Services;

namespace DB.GraphQL.Postgres.Schema;

public class Query
{
    private readonly IConnectionFactory _factory;

    public Query(IConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<string>> GetTables()
    {
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        var tables = await connection.QueryAsync<string>("select \"name\" from tables;");

        return tables;
    }
    
    private record DbColumn(string Name, string Type);

    public async Task<IEnumerable<Column>> GetColumns(string tableName)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        var columns = await connection.QueryAsync<DbColumn>("select column_name as Name, data_type as Type from information_schema.columns where table_name = @TableName;", new { TableName = tableName });
        
        return columns.Select(col => new Column(col.Name, col.Type switch
        {
            "text" => ColumnType.String,
            "integer" => ColumnType.Integer,
            "double precision" => ColumnType.Real,
            _ => throw new ArgumentOutOfRangeException()
        }));
    }

    public async Task<IEnumerable<IEnumerable<string>>> GetRows(string tableName)
    {
        if (!NameValidator.IsValid(tableName))
        {
            throw new ArgumentException("Invalid table name", nameof(tableName));
        }
        
        await using var connection = _factory.Create();
        await connection.OpenAsync();
        var rows = await connection.QueryAsync($"select * from \"{tableName}\";");
        
        return rows.Cast<IDictionary<string,object>>().Select(row => row.Values.Select(x => x.ToString() ?? "null"));
    }
    
    public record Column(string Name, ColumnType Type);
}
