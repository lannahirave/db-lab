using System.IO.Abstractions;
using System.ServiceModel;
using DB;
using DB.WebService;
using DB.WebService.Contract;
using Microsoft.AspNetCore.HttpLogging;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

var fileSystem = new FileSystem();
var path = Path.Combine(fileSystem.Directory.GetCurrentDirectory(), "db");

var exists = fileSystem.File.Exists(path);
var name = "db";
var db = exists ? await Db.LoadAsync(fileSystem, path) : await Db.CreateAsync(fileSystem, path, name);

builder.Services.AddSoapCore();
builder.Services.AddSoapExceptionTransformer((ex) => ex.Message);
builder.Services.AddSingleton<IFileSystem>(fileSystem);
builder.Services.AddSingleton(db);
builder.Services.AddSingleton<DbService>();
builder.Services.AddMvc();
builder.Services.AddHttpLogging(options => {
    options.LoggingFields = HttpLoggingFields.RequestPath;
});

var app = builder.Build();

app.UseHttpLogging();

app.UseRouting();

(app as IApplicationBuilder).UseSoapEndpoint<DbService>(
    "/db.asmx",
    new SoapEncoderOptions(),
    serializer: SoapSerializer.DataContractSerializer,
    caseInsensitivePath: true
);

app.Run();
