using System.ServiceModel;
using DB.WebService.Client.IDbService;

using var client = new DbServiceClient(new DbServiceClient.EndpointConfiguration(), "http://localhost:5237/db.asmx");
try
{
    var profile = await client.GetRowsAsync("test");
    Console.WriteLine(string.Join(", ", profile));
}
catch (FaultException ex)
{
    Console.WriteLine(ex.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
