using DB.RPC.Common;

namespace DB.WinFormsClient.DBAdapter;

public class RpcDb: IBaseDb
{
    private readonly IDbService _dbService;
    public RpcDb(IDbService dbService)
    {
        _dbService = dbService;
        DbName = "RPC db";
    }
    public async Task<List<string>> GetTables()
    {
        var tables = await _dbService.GetTables();
        return tables.ToList();
    }

    public async Task CreateTable(string tableName, IEnumerable<ColumnScheme> dbColumn)
    {
        var columns = dbColumn.Select(x => new ColumnInput(x.Name, x.Type));
        var input = new AddTableInput(tableName, columns);
        await _dbService.AddTable(input);
    }

    public async Task DeleteTable(string tableName)
    {
        await _dbService.RemoveTable(tableName);
    }

    public async Task<int> AddRow(string tableName, IDictionary<string, object> row)
    {
        var cells = row.Select(x => new CellInput {ColumnName = x.Key, Value = x.Value.ToString()!});
        return await _dbService.AddRow(tableName, cells);
    }

    public async Task UpdateRow(string tableName, int id, IDictionary<string, object> row)
    {
        var cells = row.Select(x => new CellInput {ColumnName = x.Key, Value = x.Value.ToString()!});
        await _dbService.UpdateRow(tableName, id, cells);
    }

    public async Task DeleteRow(string tableName, int id)
    {
        await _dbService.RemoveRow(tableName, id);
    }

    public async Task<List<List<object>>> GetRows(string tableName)
    {
        var rows = await _dbService.GetRows(tableName);
        return rows.Select(x => x.Select(y => (object) y).ToList()).ToList();
    }

    public async Task<List<ColumnScheme>> GetColumns(string tableName)
    {
        var columns = await _dbService.GetColumns(tableName);
        return columns.Select(x => new ColumnScheme(x.Name, x.Type)).ToList();
    }

    public List<ColumnType> GetTypes()
    {
        return Enum.GetValues<ColumnType>().ToList();
        //return new List<ColumnType>{ ColumnType.Integer, ColumnType.Real, ColumnType.String, ColumnType.Char };
    }

    public string DbName { get; }
}