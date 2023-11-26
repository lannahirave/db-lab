using Google.Protobuf.WellKnownTypes;

namespace DB.gRPC;

public static class Utils
{
    public static DateTime AsUtc(this DateTime dateTime)
    {
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
    
    public static Timestamp ToTimestamp(this DateTime dateTime)
    {
        return Timestamp.FromDateTime(dateTime.AsUtc());
    }
}
