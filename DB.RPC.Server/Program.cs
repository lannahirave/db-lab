using System.IO.Abstractions;
using CoreRPC;
using CoreRPC.Routing;
using CoreRPC.Transport.NamedPipe;
using DB;
using DB.RPC.Common;
using DB.RPC.Server;

var fileSystem = new FileSystem();
var path = Path.Combine(fileSystem.Directory.GetCurrentDirectory(), "db");

var exists = fileSystem.File.Exists(path);
var name = "db";
var db = exists ? await Db.LoadAsync(fileSystem, path) : await Db.CreateAsync(fileSystem, path, name);

var service = new DBService(db, fileSystem);

var router = new DefaultTargetSelector();
router.Register<IDbService, DBService>(service);
var engine = new Engine().CreateRequestHandler(router);

new NamedPipeHost(engine).StartListening("DbPipe");
Console.WriteLine("Server started (Listening on DbPipe)");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
