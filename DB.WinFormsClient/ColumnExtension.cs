using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using DB.WinFormsClient.DBAdapter;

namespace DB.WinFormsClient;

public static class ColumnExtension
{
    public static bool TryCast(this ColumnScheme column, object? modifiedValue, [NotNullWhen(true)]out object? result)
    {
        if (modifiedValue is not string)
        {
            result = null;
            return false;
        }

        var stringValue = (string)modifiedValue;

        if (string.IsNullOrEmpty(stringValue))
        {
            result = null;
            return false;
        }

        switch (column.Type)
        {
            case ColumnType.Integer:
            {
                var parseResult = int.TryParse(stringValue, out var value);
                result = value;
                return parseResult;
            }
            case ColumnType.Real:
            {
                var parseResult = double.TryParse(stringValue, out var value);
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
                string[] formats = { "dd.MM.yyyy", "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss"  };
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
                if (!stringValue.Contains(";"))
                {
                    result = null;
                    return false;
                }

                var stringsplit = stringValue.Split(';');
                string[] formats = { "dd.MM.yyyy", "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss"  };

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
    
    public static gRPC.Generated.ColumnType ConvertDbColumnTypeToGRpcColumnType(ColumnType columnType)
    {
        return columnType switch
        {
            ColumnType.Integer => gRPC.Generated.ColumnType.Integer,
            ColumnType.Real => gRPC.Generated.ColumnType.Real,
            ColumnType.String => gRPC.Generated.ColumnType.String,
            ColumnType.Char => gRPC.Generated.ColumnType.Char,
            ColumnType.DateTime => gRPC.Generated.ColumnType.DateTime,
            ColumnType.DateInterval => gRPC.Generated.ColumnType.DateTimeInterval,
            _ => throw new ArgumentException("Unknown column type")
        };
    }
    
    public static ColumnType ConvertGRpcColumnTypeToDbColumnType(gRPC.Generated.ColumnType columnType)
    {
        return columnType switch
        {
            gRPC.Generated.ColumnType.Integer => ColumnType.Integer,
            gRPC.Generated.ColumnType.Real => ColumnType.Real,
            gRPC.Generated.ColumnType.String => ColumnType.String,
            gRPC.Generated.ColumnType.Char => ColumnType.Char,
            gRPC.Generated.ColumnType.DateTime => ColumnType.DateTime,
            gRPC.Generated.ColumnType.DateTimeInterval => ColumnType.DateInterval,
            _ => throw new ArgumentException("Unknown column type")
        };
    }
    
    
}