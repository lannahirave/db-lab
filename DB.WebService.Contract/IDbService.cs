using System.ServiceModel;

namespace DB.WebService.Contract;

public class TableColumn
{
    public required string Name { get; set; }
    public required ColumnType Type { get; set; }
}

public class RowCell
{
    public required string Name { get; set; }
    public required string Value { get; set; }
}

[ServiceContract]
public interface IDbService
{
    [OperationContract]
    Task<ICollection<string>> GetTables();
    
    [OperationContract]
    Task CreateTable(string tableName, IEnumerable<TableColumn> dbColumn);
    
    [OperationContract]
    Task DeleteTable(string tableName);
    
    [OperationContract]
    Task AddRow(string tableName, IEnumerable<RowCell> row);
    
    [OperationContract]
    Task UpdateRow(string tableName, int id, IEnumerable<RowCell> row);
    
    [OperationContract]
    Task DeleteRow(string tableName, int id);
    
    [OperationContract]
    Task<ICollection<string>> GetRows(string tableName);
    
    [OperationContract]
    Task<ICollection<TableColumn>> GetColumns(string tableName);
}
