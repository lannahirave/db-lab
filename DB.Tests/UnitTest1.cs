using System.IO.Abstractions.TestingHelpers;

namespace DB.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public async Task TestRemoveTable()
    {
        var fileSystem = new MockFileSystem();
        var db = await Db.CreateAsync(fileSystem, "/hello.db", "hello");

        db.AddTable("testTable", new[]
        {
            ("id", ColumnType.Integer),
            ("name", ColumnType.String)
        });

        db.RemoveTable("testTable");

        Assert.IsFalse(db.Schema.Tables.ContainsKey("testTable"));
    }

    [Test]
    public async Task TestAddTable()
    {
        var fileSystem = new MockFileSystem();
        var db = await Db.CreateAsync(fileSystem, "/hello.db", "hello");

        db.AddTable("testTable", new[]
        {
            ("id", ColumnType.Integer),
            ("name", ColumnType.String)
        });

        Assert.IsTrue(db.Schema.Tables.ContainsKey("testTable"));
    }

    [Test]
    public async Task TestSaveAndLoad()
    {
        var fileSystem = new MockFileSystem();
        var db = await Db.CreateAsync(fileSystem, "/hello.db", "hello");
        db.AddTable("users", new[]
        {
            ("int", ColumnType.Integer),
            ("name", ColumnType.String),
            ("date", ColumnType.DateTime)
        });

        var usersTable = db.Schema.Tables["users"];
        usersTable.AddRow(new Dictionary<string, object?>
        {
            { "int", 1 },
            { "name", "John Doe" },
            { "date", new DateTime(2023, 5, 10) }
        });
        usersTable.AddRow(new Dictionary<string, object?>
        {
            { "int", 3 },
            { "name", "Valeraaaaaaaaaaaaaa Doe" },
            { "date", new DateTime(2023, 11, 10) }
        });
        usersTable.RemoveRow(1);
        usersTable.UpdateRow(2, new Dictionary<string, object?>
        {
            { "int", 4 },
            { "name", "Joe Joe" },

            { "date", new DateTime(2023, 2, 10) }
        });


        await db.SaveAsync(fileSystem);

        var db2 = await Db.LoadAsync(fileSystem, "/hello.db");

        Assert.That(db2.Schema.Name, Is.EqualTo(db.Schema.Name));
    }
}