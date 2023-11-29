namespace DB.WinFormsClient.DBAdapter;

public class GRpcDb: IBaseDb
{
    public async Task<List<string>> GetTables()
    {
        throw new NotImplementedException();
    }

    public async Task CreateTable(string tableName, IEnumerable<ColumnScheme> dbColumn)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTable(string tableName)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddRow(string tableName, IDictionary<string, object> row)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRow(string tableName, int id, IDictionary<string, object> row)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRow(string tableName, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<List<object>>> GetRows(string tableName)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ColumnScheme>> GetColumns(string tableName)
    {
        throw new NotImplementedException();
    }

    public List<ColumnType> GetTypes()
    {
        throw new NotImplementedException();
    }

    public string DbName { get; }
}