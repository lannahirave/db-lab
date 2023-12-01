using System.IO.Abstractions;
using Dapper;
using DB;
using DB.GraphQL.Postgres.Schema;
using DB.GraphQL.Postgres.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionFactory, PostgresConnectionFactory>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .ModifyOptions(o => o.EnableOneOf = true);

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/health", async (IConnectionFactory factory) => {
    await using var connection = factory.Create();
    await connection.QueryAsync("SELECT 1;");
    return Results.Ok("OK");
});

app.Run();
