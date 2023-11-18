namespace DB.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var fileSystem = new System.IO.Abstractions.TestingHelpers.MockFileSystem();
        var db = await Db.CreateAsync(fileSystem, "/hello.db", "hello");
        db.AddTable("users", new []
        {
            ("int", ColumnType.Integer),
            ("name", ColumnType.String)
        });

        var usersTable = db.Schema.Tables["users"];
        usersTable.AddRow(new Dictionary<string, object?>()
        {
            {"int", 1},
            {"name", "John Doe"}
        });
        usersTable.AddRow(new Dictionary<string, object?>()
        {
            {"int", 3},
            {"name", "Valeraaaaaaaaaaaaaa Doe"}
        });
        usersTable.DuplicateRow(1);
        usersTable.RemoveRow(1);
        usersTable.DuplicateRow(2);
        usersTable.UpdateRow(2, new Dictionary<string, object?>()
        {
            {"int", 4},
            {"name", "Joe Joe"}
        });
        
        
        await db.SaveAsync(fileSystem);
        
        var db2 = await Db.LoadAsync(fileSystem, "/hello.db");
        
        Assert.Pass();
    }
}
