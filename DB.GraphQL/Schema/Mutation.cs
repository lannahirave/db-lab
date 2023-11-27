using System.IO.Abstractions;

namespace DB.GraphQL.Schema;

public class Mutation
{
    private readonly IFileSystem _fileSystem;
    private readonly Db _db;

    public Mutation(Db db, IFileSystem fileSystem)
    {
        _db = db;
        _fileSystem = fileSystem;
    }
    
    public async Task<AddTablePayload> AddTable(AddTableInput input)
    {
        _db.AddTable(input.Name, input.Columns.Select(x => (x.Name, x.Type)));
        await _db.SaveAsync(_fileSystem);
        return new AddTablePayload(input.Name);
    }
    
    public async Task<bool> RemoveTable(string tableName)
    {
        _db.RemoveTable(tableName);
        await _db.SaveAsync(_fileSystem);
        return true;
    }
    
    public async Task<bool> AddRow(string tableName, IEnumerable<CellInput> row)
    {
        _db.Schema.Tables[tableName].AddRow(row.ToDictionary(x => x.ColumnName, x => (object?)x.Value.String ?? (object?)x.Value.Int ?? (object?)x.Value.Real));
        await _db.SaveAsync(_fileSystem);
        return true;
    }
    
    public async Task<bool> RemoveRow(string tableName, int id)
    {
        _db.Schema.Tables[tableName].RemoveRow(id);
        await _db.SaveAsync(_fileSystem);
        return true;
    }
    
    public async Task<bool> UpdateRow(string tableName, int id, IEnumerable<CellInput> row)
    {
        _db.Schema.Tables[tableName].UpdateRow(id, row.ToDictionary(x => x.ColumnName, x => (object?)x.Value.String ?? (object?)x.Value.Int ?? (object?)x.Value.Real));
        await _db.SaveAsync(_fileSystem);
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
