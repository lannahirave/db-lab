using System.IO.Abstractions;
using DB;
using DB.gRPC.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

var fileSystem = new FileSystem();
var path = Path.Combine(fileSystem.Directory.GetCurrentDirectory(), "db");

var exists = fileSystem.File.Exists(path);
var name = "db";
var db = exists ? await Db.LoadAsync(fileSystem, path) : await Db.CreateAsync(fileSystem, path, name);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddSingleton<IFileSystem>(fileSystem);
builder.Services.AddSingleton(db);

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.MapGrpcService<DbService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
