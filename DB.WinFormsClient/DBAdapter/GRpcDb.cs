using DB;
using DB.gRPC.Generated;
using DB.WinFormsClient;
using DB.WinFormsClient.DBAdapter;
using Google.Protobuf.WellKnownTypes;
using Column = DB.gRPC.Generated.Column;
using ColumnType = DB.ColumnType;

public class GRpcDb : IBaseDb
{
    private readonly DB.gRPC.Generated.DB.DBClient _client;
    
    public GRpcDb(DB.gRPC.Generated.DB.DBClient client)
    {
        _client = client;
        DbName = "gRPC db";
    }
    
    public async Task<List<string>> GetTables()
    {
        var tables = await _client.GetTablesAsync(new Empty());
        return tables.Tables.ToList();
    }

    public async Task CreateTable(string tableName, IEnumerable<ColumnScheme> dbColumn)
    {
        await _client.CreateTableAsync(new CreateTableRequest()
        {
            TableName = tableName,
            Columns = { dbColumn.Select(x => new Column {Name = x.Name, Type = ColumnExtension.ConvertDbColumnTypeToGRpcColumnType(x.Type)}) }
        });
    }

    public async Task DeleteTable(string tableName)
    {
        await _client.DeleteTableAsync(new DeleteTableRequest
        {
            TableName = tableName
        });
    }

    public async Task<int> AddRow(string tableName, IDictionary<string, object> row)
    {
        var response = await _client.AddRowAsync(new AddRowRequest
        {
            TableName = tableName,
            Row = { row.Select(x => x.Value switch
            {
                int a => new Cell {Name = x.Key, IntValue = a},
                double a => new Cell {Name = x.Key, FloatValue = (float)a},
                string a => new Cell {Name = x.Key, StringValue = a},
                _ => throw new NotImplementedException()
            }) }
        });
        return response.Id;
    }

    public async Task UpdateRow(string tableName, int id, IDictionary<string, object> row)
    {
        await _client.UpdateRowAsync(new UpdateRowRequest()
        {
            Id = id,
            TableName = tableName,
            Row = { row.Select(x => x.Value switch
            {
                int a => new Cell {Name = x.Key, IntValue = a},
                double a => new Cell {Name = x.Key, FloatValue = (float)a},
                string a => new Cell {Name = x.Key, StringValue = a},
                _ => throw new NotImplementedException()
            }) }
        });
    }

    public async Task DeleteRow(string tableName, int id)
    {
        await _client.DeleteRowAsync(new DeleteRowRequest
        {
            Id = id,
            TableName = tableName
        });
    }

    public async Task<List<List<object>>> GetRows(string tableName)
    {
        var response = await _client.GetRowsFormattedAsync(new GetRowsRequest
        {
            TableName = tableName
        });
        return response.Rows.Select(x => x.Cells.Cast<object>().ToList()).ToList();
    }

    public async Task<List<ColumnScheme>> GetColumns(string tableName)
    {
        var response = await _client.GetColumnsAsync(new GetColumnsRequest
        {
            TableName = tableName
        });
        return response.Columns.Select(x => new ColumnScheme(x.Name, ColumnExtension.ConvertGRpcColumnTypeToDbColumnType(x.Type))).ToList();
    }

    public List<ColumnType> GetTypes()
    {
        return new List<ColumnType>
        {
            ColumnType.Integer,
            ColumnType.Real,
            ColumnType.String
        };
    }

    public string DbName { get; private set; }
}