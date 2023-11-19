namespace DB;

public class DbSchema
{
    public required string Name { get; set; }
    
    public required Dictionary<string, Table> Tables { get; set; }
    
    public void WriteBinary(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Tables.Count);
        foreach (var entry in Tables)
        {
            writer.Write(entry.Key);
            entry.Value.WriteBinary(writer);
        }
    }
    
    public static DbSchema ReadBinary(BinaryReader reader)
    {
        var schema = new DbSchema
        {
            Name = reader.ReadString(),
            Tables = new Dictionary<string, Table>()
        };
        
        var tableCount = reader.ReadInt32();
        for (var i = 0; i < tableCount; i++)
        {
            var tableName = reader.ReadString();
            schema.Tables[tableName] = Table.ReadBinary(reader);
        }
    
        return schema;
    }
    
    

}

public class Table
{
    private string _name;
    private List<Column> _columns;
    private int _idCounter;
    private IDictionary<int, List<object>> _rows;

    public IReadOnlyCollection<Column> Columns => _columns;
    public ICollection<List<object>> Rows => _rows.Values;
    
    private Table(string name, List<Column> columns)
    {
        _name = name;
        _columns = columns;
        _rows = new Dictionary<int, List<object>>();
    }

    public static Table Create(string name, List<Column> columns)
    {
        var defaultColumns = new[] { new Column{ Name = "$id", Type = ColumnType.Integer} };
        return new Table(name, defaultColumns.Concat(columns).ToList());
    }

    public int AddRow(IDictionary<string, object?> row)
    {
        var id = _idCounter++;
        _rows[id] = _columns.Select(x =>
        {
            if (x.Name == "$id")
            { 
                return id;
            }

            var cell = row[x.Name];
            if (cell == null)
            {
                throw new Exception($"Column {x.Name} is missing");
            }
            return cell;
        }).ToList();
        return id;
    }

    public void UpdateRow(int id, IDictionary<string, object?> row)
    {
        _rows[id] = _columns.Select(x =>
        {
            if (x.Name == "$id")
            {
                return id;
            }

            var cell = row[x.Name];
            if (cell == null)
            {
                throw new Exception($"Column ${x.Name} is missing");
            }
            return cell;
        }).ToList();
    }

    public void RemoveRow(int id) {
        _rows.Remove(id);
    }
    
    public void WriteBinary(BinaryWriter writer)
    {
        writer.Write(_name);
        writer.Write(_idCounter);
        
        writer.Write(_columns.Count);
        foreach (var column in _columns)
        {
            column.WriteBinary(writer);
        }
        
        writer.Write(_rows.Count);
        foreach (var row in _rows.Values)
        {
            for (var i = 0; i < _columns.Count; ++i)
            {
                var column = _columns[i];
                writer.WriteColumnData(column, row[i]);
            }
        }
    }
    
    public static Table ReadBinary(BinaryReader reader)
    {
        var tableName = reader.ReadString();
        var idCounter = reader.ReadInt32();
        var table = new Table(tableName, new List<Column>());
        table._idCounter = idCounter;
        
        var columnCount = reader.ReadInt32();
        for (var i = 0; i < columnCount; i++)
        {
            table._columns.Add(Column.ReadBinary(reader));
        }
        
        var rowsCount = reader.ReadInt32();
        for (var i = 0; i < rowsCount; i++)
        {
            int id = -1;
            var row = new List<object>();
            for (var j = 0; j < columnCount; j++)
            {
                var column = table._columns[j];
                var cell = reader.ReadColumnData(column);
                if (column.Name == "$id")
                {
                    id = (int)cell;
                }
                row.Add(cell);
            }
            
            if (id == -1)
            {
                throw new Exception("Row is missing id");
            }
            
            table._rows[id] = row;
        }

        return table;
    }
}
