using System.Data;
using System.Data.Common;

namespace DB.GraphQL.Postgres.Services;

public interface IConnectionFactory
{
    public DbConnection Create();
}
