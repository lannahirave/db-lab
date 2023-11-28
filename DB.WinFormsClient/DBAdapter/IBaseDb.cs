namespace DB.WinFormsClient.DBAdapter;

public record ColumnScheme(string Name, ColumnType Type);

public interface IBaseDb
{ 
    Task<List<string>> GetTables();
    Task CreateTable(string tableName, IEnumerable<ColumnScheme> dbColumn);
    Task DeleteTable(string tableName);
    Task<int> AddRow(string tableName, IDictionary<string, object> row);
    Task UpdateRow(string tableName, int id, IDictionary<string, object> row);
    Task DeleteRow(string tableName, int id);
    Task<List<List<Object>>> GetRows(string tableName);
    Task<List<ColumnScheme>> GetColumns(string tableName);
    List<ColumnType> GetTypes();
    string DbName { get; }
}