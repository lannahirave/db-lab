namespace DB;

public enum ColumnType
{
    Integer,
    Real,
    Char,
    String,
    DateTime,
    DateInterval
}

public static class ColumnUtils
{
    public static void WriteColumnData(this BinaryWriter writer, Column column, object value)
    {
        switch (column.Type)
        {
            case ColumnType.Integer:
                writer.Write((int)value);
                break;
            case ColumnType.Real:
                writer.Write((double)value);
                break;
            case ColumnType.Char:
                writer.Write((char)value);
                break;
            case ColumnType.String:
                writer.Write((string)value);
                break;
            case ColumnType.DateTime:
                writer.Write(((DateTime)value).ToBinary());
                break;
            case ColumnType.DateInterval:
                ((DateInterval)value).WriteBinary(writer);
                break;
        }
    }

    public static object ReadColumnData(this BinaryReader reader, Column column)
    {
        return column.Type switch
        {
            ColumnType.Integer => reader.ReadInt32(),
            ColumnType.Real => reader.ReadDouble(),
            ColumnType.Char => reader.ReadChar(),
            ColumnType.String => reader.ReadString(),
            ColumnType.DateTime => DateTime.FromBinary(reader.ReadInt64()),
            ColumnType.DateInterval => DateInterval.ReadBinary(reader),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public class Column
{
    public required string Name { get; set; }
    public required ColumnType Type { get; set; }

    public void WriteBinary(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write((int)Type);
    }

    public static Column ReadBinary(BinaryReader reader)
    {
        return new Column
        {
            Name = reader.ReadString(),
            Type = (ColumnType)reader.ReadInt32()
        };
    }
}