using CoreRPC;
using CoreRPC.Transport.NamedPipe;
using DB.RPC.Common;
var transport = new NamedPipeClientTransport("DbPipe");

var proxy = new Engine().CreateProxy<IDbService>(transport);
var res = await proxy.GetTables();
foreach (var table in res)
{
    Console.WriteLine(table);
}
