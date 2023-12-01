using System.Data;
using System.Data.Common;
using Npgsql;

namespace DB.GraphQL.Postgres.Services;

public class PostgresConnectionFactory : IConnectionFactory
{
    public DbConnection Create()
    {
        return new NpgsqlConnection("User ID=postgres;Password=test12345;Host=localhost;Port=5432;Database=db-lab;");
    }
}
