using System.IO.Abstractions;
using DB.RPC.Common;

namespace DB.RPC.Server;

public class DbService : IDbService
{
    private readonly Db _db;
    private readonly IFileSystem _fileSystem;

    public DbService(Db db, IFileSystem fileSystem)
    {
        _db = db;
        _fileSystem = fileSystem;
    }

    public Task<IEnumerable<string>> GetTables()
    {
        return Task.FromResult<IEnumerable<string>>(_db.Schema.Tables.Keys);
    }

    public Task<IEnumerable<IDbService.Column>> GetColumns(string tableName)
    {
        return Task.FromResult(_db.Schema.Tables[tableName].Columns.Select(x => new IDbService.Column(x.Name, x.Type)));
    }

    public Task<IEnumerable<IEnumerable<string>>> GetRows(string tableName)
    {
        return Task.FromResult(_db.Schema.Tables[tableName].Rows
            .Select(x => x.Select(cell => cell.ToString() ?? "null")));
    }

    public async Task AddTable(AddTableInput input)
    {
        _db.AddTable(input.Name, input.Columns.Select(x => (x.Name, x.Type)));
        await _db.SaveAsync(_fileSystem);
    }

    public async Task RemoveTable(string tableName)
    {
        _db.RemoveTable(tableName);
        await _db.SaveAsync(_fileSystem);
    }

    public async Task<int> AddRow(string tableName, IEnumerable<CellInput> row)
    {
        var id = _db.Schema.Tables[tableName].AddRow(row.Select(x => (x.ColumnName, x.Value)));
        await _db.SaveAsync(_fileSystem);
        return id;
    }


    public async Task RemoveRow(string tableName, int id)
    {
        _db.Schema.Tables[tableName].RemoveRow(id);
        await _db.SaveAsync(_fileSystem);
    }

    public async Task UpdateRow(string tableName, int id, IEnumerable<CellInput> row)
    {
        _db.Schema.Tables[tableName].UpdateRow(id,
            row.ToDictionary(x => x.ColumnName, x => (object?)x.Value ?? (object?)x.Value ?? (object?)x.Value));
        await _db.SaveAsync(_fileSystem);
    }
}