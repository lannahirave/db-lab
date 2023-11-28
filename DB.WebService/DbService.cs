using System.IO.Abstractions;
using DB.WebService.Contract;

namespace DB.WebService;

public class DbService : IDbService
{
    private readonly IFileSystem _fileSystem;
    private readonly Db _db;
    
    public DbService(Db db, IFileSystem fileSystem)
    {
        _db = db;
        _fileSystem = fileSystem;
    }

    public Task<ICollection<string>> GetTables()
    {
        return Task.FromResult<ICollection<string>>(_db.Schema.Tables.Keys);
    }
    
    public async Task CreateTable(string tableName, IEnumerable<TableColumn> dbColumn)
    {
        _db.AddTable(tableName, dbColumn.Select(x => (x.Name, x.Type)));
        await _db.SaveAsync(_fileSystem);
    }
    
    public async Task DeleteTable(string tableName)
    {
        _db.RemoveTable(tableName);
        await _db.SaveAsync(_fileSystem);
    }
    
    public async Task AddRow(string tableName, IEnumerable<RowCell> row)
    {
        _db.Schema.Tables[tableName].AddRow(row.Select(x => (x.Name, x.Value)));
        await _db.SaveAsync(_fileSystem);
    }
    
    public async Task UpdateRow(string tableName, int id, IEnumerable<RowCell> row)
    {
        _db.Schema.Tables[tableName].UpdateRow(id, row.Select(x => (x.Name, x.Value)));
        await _db.SaveAsync(_fileSystem);
    }
    
    public async Task DeleteRow(string tableName, int id)
    {
        _db.Schema.Tables[tableName].RemoveRow(id);
        await _db.SaveAsync(_fileSystem);
    }
    
    public Task<ICollection<string>> GetRows(string tableName)
    {
        var delimiter = "§";
        var header = string.Join(delimiter, _db.Schema.Tables[tableName].Columns.Select(x => x.Type.ToString()));
        var rows = _db.Schema.Tables[tableName].GetSerializedRows().Select(x => string.Join(delimiter, x));

        var result = new List<string>
        {
            delimiter,
            header
        };

        result.AddRange(rows);
        
        return Task.FromResult<ICollection<string>>(result);
    }
    
    public Task<ICollection<TableColumn>> GetColumns(string tableName)
    {
        return Task.FromResult<ICollection<TableColumn>>(_db.Schema.Tables[tableName].Columns.Select(x => new TableColumn
        {
            Name = x.Name,
            Type = x.Type
        }).ToList());
    }
}
