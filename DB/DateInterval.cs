namespace DB;

public class DateInterval
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public DateInterval(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
    
    public void WriteBinary(BinaryWriter writer)
    {
        writer.Write(Start.Ticks);
        writer.Write(End.Ticks);
    }
    
    public static DateInterval ReadBinary(BinaryReader reader)
    {
        return new DateInterval(new DateTime(reader.ReadInt64()), new DateTime(reader.ReadInt64()));
    }
    
    public override string ToString()
    {
        return $"{Start:dd.MM.yyyy};{End:dd.MM.yyyy}";
    }
    
}