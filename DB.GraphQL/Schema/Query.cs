namespace DB.GraphQL.Schema;

public class Query
{
    private readonly Db _db;

    public Query(Db db)
    {
        _db = db;
    }

    public IEnumerable<string> GetTables()
    {
        return _db.Schema.Tables.Keys;
    }

    public IEnumerable<Column> GetColumns(string tableName)
    {
        return _db.Schema.Tables[tableName].Columns.Select(x => new Column(x.Name, x.Type));
    }

    public IEnumerable<IEnumerable<string>> GetRows(string tableName)
    {
        return _db.Schema.Tables[tableName].Rows.Select(x => x.Select(cell => cell.ToString() ?? "null"));
    }
    
    public record Column(string Name, ColumnType Type);
}
