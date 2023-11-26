using System.Globalization;
using DB;

namespace WinFormsApp1;

public static class ColumnExtension
{
    public static bool TryCast(this Column column, object? modifiedValue, out object? result)
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
            return true;
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
                if (!stringValue.Contains(";"))
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
}