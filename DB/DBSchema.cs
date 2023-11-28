using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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
    private readonly List<Column> _columns;
    private int _idCounter;
    private readonly string _name;
    private readonly IDictionary<int, List<object>> _rows;

    private Table(string name, List<Column> columns)
    {
        _name = name;
        _columns = columns;
        _rows = new Dictionary<int, List<object>>();
    }

    public IReadOnlyCollection<Column> Columns => _columns;
    public ICollection<List<object>> Rows => _rows.Values;
    
    public ICollection<List<string>> GetSerializedRows()
    {
        return _rows.Values.Select(x => x.Select(cell => cell.ToString() ?? "null").ToList()).ToList();
    }

    public static Table Create(string name, List<Column> columns)
    {
        var defaultColumns = new[] { new Column { Name = "$id", Type = ColumnType.Integer } };
        return new Table(name, defaultColumns.Concat(columns).ToList());
    }

    public IDictionary<string, object?> CastRow(IEnumerable<(string Name, string Value)> row)
    {
        var rowDict = row.ToDictionary(x => x.Name, x => x.Value); 
        return _columns
            .Where(x => x.Name != "$id")
            .Select(x => {
                var cell = rowDict[x.Name];
                
                if (!TryCast(x.Type, cell, out var result))
                    throw new Exception($"Column {x.Name} has wrong type");
                return (Name: x.Name, Value: result);
            })
            .ToDictionary(x => x.Name, x => x.Value)!;
    }
    
    public static bool TryCast(ColumnType type, object? modifiedValue, [NotNullWhen(true)] out object? result)
    {
        if (modifiedValue is not string stringValue)
        {
            result = null;
            return false;
        }

        if (string.IsNullOrEmpty(stringValue))
        {
            result = null;
            return false;
        }

        switch (type)
        {
            case ColumnType.Integer:
            {
                var parseResult = int.TryParse(stringValue, out var value);
                result = value;
                return parseResult;
            }
            case ColumnType.Real:
            {
                var parseResult = double.TryParse(stringValue, CultureInfo.InvariantCulture, out var value);
                result = value;
                return parseResult;
            }
            case ColumnType.Char:
            {
                var parseResult = char.TryParse(stringValue, out var value);
                result = value;
                return parseResult;
            }
            case ColumnType.String:
            {
                result = stringValue;
                return true;
            }
            case ColumnType.DateTime:
            {
                string[] formats = { "dd.MM.yyyy" };
                var parseResult = DateTime.TryParseExact(stringValue, formats, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var value);
                if (!parseResult)
                {
                    result = null;
                    return false;
                }

                result = value;
                return true;
            }
            case ColumnType.DateInterval:
            {
                if (!stringValue.Contains(';'))
                {
                    result = null;
                    return false;
                }

                var stringsplit = stringValue.Split(';');
                string[] formats = { "dd.MM.yyyy" };

                var parseResult1 = DateTime.TryParseExact(stringsplit[0], formats, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var value1);
                var parseResult2 = DateTime.TryParseExact(stringsplit[1], formats, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var value2);

                if (!parseResult1 || !parseResult2)
                {
                    result = null;
                    return false;
                }

                result = new DateInterval(value1, value2);
                return parseResult1 && parseResult2;
            }

            default:
                result = null;
                return false;
        }
    }

    public int AddRow(IEnumerable<(string Name, string Value)> row)
    {
        return AddRow(CastRow(row));
    }
    
    public int AddRow(IDictionary<string, object?> row)
    {
        var id = _idCounter++;
        _rows[id] = _columns.Select(x =>
        {
            if (x.Name == "$id") return id;

            var cell = row[x.Name];
            if (cell == null) throw new Exception($"Column {x.Name} is missing");
            if (cell.GetType() != x.Type.GetColumnType()) throw new Exception($"Column {x.Name} has wrong type");
            return cell;
        }).ToList();
        return id;
    }
    
    public void UpdateRow(int id, IEnumerable<(string Name, string Value)> row)
    {
        UpdateRow(id, CastRow(row));
    }

    public void UpdateRow(int id, IDictionary<string, object?> row)
    {
        _rows[id] = _columns.Select(x =>
        {
            if (x.Name == "$id") return id;

            var cell = row[x.Name];
            if (cell == null) throw new Exception($"Column ${x.Name} is missing");
            return cell;
        }).ToList();
    }

    public void RemoveRow(int id)
    {
        _rows.Remove(id);
    }

    public void WriteBinary(BinaryWriter writer)
    {
        writer.Write(_name);
        writer.Write(_idCounter);

        writer.Write(_columns.Count);
        foreach (var column in _columns) column.WriteBinary(writer);

        writer.Write(_rows.Count);
        foreach (var row in _rows.Values)
            for (var i = 0; i < _columns.Count; ++i)
            {
                var column = _columns[i];
                writer.WriteColumnData(column, row[i]);
            }
    }

    public static Table ReadBinary(BinaryReader reader)
    {
        var tableName = reader.ReadString();
        var idCounter = reader.ReadInt32();
        var table = new Table(tableName, new List<Column>());
        table._idCounter = idCounter;

        var columnCount = reader.ReadInt32();
        for (var i = 0; i < columnCount; i++) table._columns.Add(Column.ReadBinary(reader));

        var rowsCount = reader.ReadInt32();
        for (var i = 0; i < rowsCount; i++)
        {
            var id = -1;
            var row = new List<object>();
            for (var j = 0; j < columnCount; j++)
            {
                var column = table._columns[j];
                var cell = reader.ReadColumnData(column);
                if (column.Name == "$id") id = (int)cell;
                row.Add(cell);
            }

            if (id == -1) throw new Exception("Row is missing id");

            table._rows[id] = row;
        }

        return table;
    }
}
