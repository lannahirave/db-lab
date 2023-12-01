using System.Text.RegularExpressions;

namespace DB.GraphQL.Postgres.Helpers;

public static class NameValidator
{
    private static readonly Regex _nameRegex = new("^[a-zA-Z][a-zA-Z0-9_-]{0,32}$");
    
    public static bool IsValid(string name)
    {
        return _nameRegex.IsMatch(name);
    }
}
