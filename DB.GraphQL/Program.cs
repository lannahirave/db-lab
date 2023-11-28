using System.IO.Abstractions;
using DB;
using DB.GraphQL.Schema;

var builder = WebApplication.CreateBuilder(args);

var fileSystem = new FileSystem();
var path = System.IO.Path.Combine(fileSystem.Directory.GetCurrentDirectory(), "db");

var exists = fileSystem.File.Exists(path);
var name = "db";
var db = exists ? await Db.LoadAsync(fileSystem, path) : await Db.CreateAsync(fileSystem, path, name);

builder.Services.AddSingleton<IFileSystem>(fileSystem);
builder.Services.AddSingleton(db);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .ModifyOptions(o => o.EnableOneOf = true);

var app = builder.Build();

app.MapGraphQL();

app.Run();
