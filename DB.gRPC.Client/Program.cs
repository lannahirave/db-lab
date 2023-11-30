// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("http://localhost:5002");
var client = new DB.gRPC.Generated.DB.DBClient(channel);

var tables = await client.GetTablesAsync(new Empty());

foreach (var table in tables.Tables)
{
    Console.WriteLine(table);
}
