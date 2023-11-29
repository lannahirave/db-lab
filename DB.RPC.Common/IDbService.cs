namespace DB.RPC.Common;

public interface IDbService
{
    public Task<IEnumerable<string>> GetTables();
    public Task<IEnumerable<Column>> GetColumns(string tableName);
    public Task<IEnumerable<IEnumerable<string>>> GetRows(string tableName);

    public Task AddTable(AddTableInput input);
    public Task RemoveTable(string tableName);

    public Task<int> AddRow(string tableName, IEnumerable<CellInput> row);
    public Task RemoveRow(string tableName, int id);
    public Task UpdateRow(string tableName, int id, IEnumerable<CellInput> row);

    public record Column(string Name, ColumnType Type);
}

public record AddTableInput(string Name, IEnumerable<ColumnInput> Columns);

public record ColumnInput(string Name, ColumnType Type);

public class CellInput
{
    public string ColumnName { get; init; } = null!;

    public string Value { get; init; } = null!;
}