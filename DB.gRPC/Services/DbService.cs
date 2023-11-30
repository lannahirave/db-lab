using System.IO.Abstractions;
using Grpc.Core;
using DB.gRPC.Generated;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;

namespace DB.gRPC.Services;

public class DbService : Generated.DB.DBBase
{
    private readonly IFileSystem _fileSystem;
    private readonly Db _db;
    
    public DbService(Db db, IFileSystem fileSystem)
    {
        _db = db;
        _fileSystem = fileSystem;
    }

    public override Task<GetTablesResponse> GetTables(Empty request, ServerCallContext context)
    {
        var response = new GetTablesResponse();
        response.Tables.AddRange(_db.Schema.Tables.Keys);
        return Task.FromResult(response);
    }

    public override async Task<OperationResponse> CreateTable(CreateTableRequest request, ServerCallContext context)
    {
        _db.AddTable(request.TableName, request.Columns.Select(x => (x.Name, ToDbColumnType(x.Type))));
        await _db.SaveAsync(_fileSystem);
        
        return new OperationResponse
        {
            Success = true,
            Message = "Table created"
        };
    }
    
    public override async Task<OperationResponse> DeleteTable(DeleteTableRequest request, ServerCallContext context)
    {
        _db.RemoveTable(request.TableName);
        await _db.SaveAsync(_fileSystem);
        
        return new OperationResponse
        {
            Success = true,
            Message = "Table deleted"
        };
    }

    public override async Task<RowOperationResponse> AddRow(AddRowRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return new RowOperationResponse
            {
                Success = false,
                Message = "Table not found"
            };
        }

        try
        {
            var row = MapRow(request.Row);
            var id = table.AddRow(row!);
            
            await _db.SaveAsync(_fileSystem);

            return new RowOperationResponse
            {
                Success = true,
                Message = "Row added",
                Id = id,
            };
        }
        catch (Exception e)
        {
            return new RowOperationResponse
            {
                Success = false,
                Message = e.Message,
                Id = -1,
            };
        }
    }

    public override async Task<OperationResponse> DeleteRow(DeleteRowRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return new OperationResponse
            {
                Success = false,
                Message = "Table not found"
            };
        }

        table.RemoveRow(request.Id);
        await _db.SaveAsync(_fileSystem);
        
        return new OperationResponse
        {
            Success = true,
            Message = "Row deleted"
        };
    }

    public override async Task<OperationResponse> UpdateRow(UpdateRowRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return new OperationResponse
            {
                Success = false,
                Message = "Table not found"
            };
        }

        try
        {
            var row = MapRow(request.Row);
            table.UpdateRow(request.Id, row!);
            
            await _db.SaveAsync(_fileSystem);

            return new OperationResponse
            {
                Success = true,
                Message = "Row updated",
            };
        }
        catch (Exception e)
        {
            return new OperationResponse
            {
                Success = false,
                Message = e.Message,
            };
        }
    }

    public override Task<GetColumnsResponse> GetColumns(GetColumnsRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return Task.FromResult(new GetColumnsResponse());
        }
        
        var response = new GetColumnsResponse();
        
        response.Columns.AddRange(table.Columns.Select(x => new Generated.Column
        {
            Name = x.Name,
            Type = ToProtoColumnType(x.Type)
        }));
        
        return Task.FromResult(response);
    }

    public override Task<GetRowsResponse> GetRows(GetRowsRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return Task.FromResult(new GetRowsResponse());
        }
        
        var response = new GetRowsResponse();

        var columns = table.Columns.ToList();
        var rows = table.Rows.Skip(request.Offset).Take(request.Limit);
        foreach (var dbRow in rows)
        {
            var row = new RowData();

            for (int i = 0; i < columns.Count; ++i)
            {
                var column = columns[i];
                var cell = dbRow[i];

                switch (column.Type)
                {
                    case ColumnType.Integer:
                        row.Data.Add(new CellData
                        {
                            IntValue = (int)cell
                        });
                        break;
                    case ColumnType.Real:
                        row.Data.Add(new CellData
                        {
                            FloatValue = Convert.ToSingle(cell)
                        });
                        break;
                    case ColumnType.Char:
                        row.Data.Add(new CellData
                        {
                            CharValue = (char)cell
                        });
                        break;
                    case ColumnType.String:
                        row.Data.Add(new CellData
                        {
                            StringValue = (string)cell
                        });
                        break;
                    case ColumnType.DateTime:
                        row.Data.Add(new CellData
                        {
                            DateTimeValue = ((DateTime)cell).ToTimestamp()
                        });
                        break;
                    case ColumnType.DateInterval:
                        var interval = (DateInterval)cell;
                        row.Data.Add(new CellData
                        {
                            DateTimeIntervalValue = new DateTimeInterval
                            {
                                Start = interval.Start.ToTimestamp(),
                                End = interval.End.ToTimestamp()
                            }
                        });
                        break;
                }
            }
            
            response.Rows.Add(row);
        }
        
        return Task.FromResult(response);
    }

    public override Task<GetRowsFormattedResponse> GetRowsFormatted(GetRowsRequest request, ServerCallContext context)
    {
        if (!_db.Schema.Tables.TryGetValue(request.TableName, out var table))
        {
            return Task.FromResult(new GetRowsFormattedResponse());
        }

        var response = new GetRowsFormattedResponse
        {
            Rows =
            {
                table.Rows.Select(row => new FormattedRow
                {
                    Cells = { row.Select(x => x.ToString()) }
                })
            }
        };
        
        return Task.FromResult(response);
    }

    private static ColumnType ToDbColumnType(Generated.ColumnType columnType)
    {
        return columnType switch
        {
            Generated.ColumnType.Integer => ColumnType.Integer,
            Generated.ColumnType.Real => ColumnType.Real,
            Generated.ColumnType.Char => ColumnType.Char,
            Generated.ColumnType.String => ColumnType.String,
            Generated.ColumnType.DateTime => ColumnType.DateTime,
            Generated.ColumnType.DateTimeInterval => ColumnType.DateInterval,
            _ => throw new ArgumentOutOfRangeException(nameof(columnType), columnType, null)
        };
    }
    
    private static Generated.ColumnType ToProtoColumnType(ColumnType columnType)
    {
        return columnType switch
        {
            ColumnType.Integer => Generated.ColumnType.Integer,
            ColumnType.Real => Generated.ColumnType.Real,
            ColumnType.Char => Generated.ColumnType.Char,
            ColumnType.String => Generated.ColumnType.String,
            ColumnType.DateTime => Generated.ColumnType.DateTime,
            ColumnType.DateInterval => Generated.ColumnType.DateTimeInterval,
            _ => throw new ArgumentOutOfRangeException(nameof(columnType), columnType, null)
        };
    }

    private Dictionary<string, object> MapRow(RepeatedField<Cell> row)
    {
        return row.ToDictionary(x => x.Name, x => {
            object value = x.ValueCase switch
            {
                Cell.ValueOneofCase.IntValue => x.IntValue,
                Cell.ValueOneofCase.FloatValue => (double) x.FloatValue,
                Cell.ValueOneofCase.CharValue => (char) x.CharValue,
                Cell.ValueOneofCase.StringValue => x.StringValue,
                Cell.ValueOneofCase.DateTimeValue => x.DateTimeValue.ToDateTime(),
                Cell.ValueOneofCase.DateTimeIntervalValue => new DateInterval(
                x.DateTimeIntervalValue.Start.ToDateTime(),
                x.DateTimeIntervalValue.End.ToDateTime()
                ),
                _ => throw new ArgumentOutOfRangeException()
            };
            return value;
        });
    }
}
