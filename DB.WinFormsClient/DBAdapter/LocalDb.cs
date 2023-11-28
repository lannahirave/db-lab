namespace DB.WinFormsClient.DBAdapter;

public class LocalDb: IBaseDb
{
    
    private readonly Db _db;

    public LocalDb(Db db)
    {
        _db = db;
        DbName = "localdb";
    }
    
    public  Task<List<string>> GetTables()
    {
        return Task.FromResult(_db.Schema.Tables.Keys.ToList());
    }

    public async Task CreateTable(string tableName, IEnumerable<ColumnScheme> dbColumn)
    {
        _db.AddTable(tableName, dbColumn.Select(x => (x.Name, x.Type)));
        await _db.SaveAsync(Utility.Filesystem);
    }

    public async Task DeleteTable(string tableName)
    {
        _db.RemoveTable(tableName);
        await _db.SaveAsync(Utility.Filesystem);
    }

    public async Task<int> AddRow(string tableName, IDictionary<string, object> row)
    {
        int id = _db.Schema.Tables[tableName].AddRow(row!);
        await _db.SaveAsync(Utility.Filesystem);
        return id;
    }

    public async Task UpdateRow(string tableName, int id, IDictionary<string, object> row)
    {
        _db.Schema.Tables[tableName].UpdateRow(id, row!);
        await _db.SaveAsync(Utility.Filesystem);
    }

    public async Task DeleteRow(string tableName, int id)
    {
        _db.Schema.Tables[tableName].RemoveRow(id);
        
        await _db.SaveAsync(Utility.Filesystem);
    }

    public Task<List<List<object>>> GetRows(string tableName)
    {
        return Task.FromResult(_db.Schema.Tables[tableName].Rows.ToList());
    }

    public Task<List<ColumnScheme>> GetColumns(string tableName)
    {
        return Task.FromResult(_db.Schema.Tables[tableName].Columns.Select(x => new ColumnScheme(x.Name, x.Type)).ToList());
    }

    public List<ColumnType> GetTypes()
    {
        return Enum.GetValues<ColumnType>().ToList();
    }

    public string DbName { get; }
}