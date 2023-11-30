using System.IO.Abstractions;

namespace DB;

public class DbLoadError : Exception
{
    public DbLoadError(string message) : base(message)
    {
    }
}

public class Db
{
    private Db(string path, DbSchema schema)
    {
        Path = path;
        Schema = schema;
    }

    public string Path { get; }
    public DbSchema Schema { get; }

    public void AddTable(string name, IEnumerable<(string name, ColumnType type)> columns)
    {
        var tableColumns = columns.Select(x => new Column
        {
            Name = x.name,
            Type = x.type
        }).ToList();
        Schema.Tables[name] = Table.Create(name, tableColumns);
    }

    public void AddTable(string name, Table table)
    {
        Schema.Tables[name] = table;
    }

    public void RemoveTable(string name)
    {
        Schema.Tables.Remove(name);
    }

    public static async Task<Db> CreateAsync(IFileSystem fileSystem, string path, string name)
    {
        var schema = new DbSchema
        {
            Name = name,
            Tables = new Dictionary<string, Table>()
        };
        var db = new Db(path, schema);

        await db.SaveAsync(fileSystem);

        return db;
    }

    public async Task SaveAsync(IFileSystem fileSystem)
    {
        await using var file = EnsureExists(fileSystem, Path);

        using var stream = new MemoryStream();
        var writer = new BinaryWriter(stream);

        Schema.WriteBinary(writer);

        stream.WriteTo(file);
        await file.FlushAsync();
        await file.DisposeAsync();
    }

    public static async Task<Db> LoadAsync(IFileSystem fileSystem, string path)
    {
        await using var file = EnsureExists(fileSystem, path);

        var reader = new BinaryReader(file);
        var schema = DbSchema.ReadBinary(reader);
        reader.Dispose();
        return new Db(path, schema);
    }

    private static FileSystemStream EnsureExists(IFileSystem fileSystem, string path)
    {
        var directory = System.IO.Path.GetDirectoryName(path);

        if (directory is null) throw new Exception("Invalid path");

        if (!fileSystem.File.Exists(path))
        {
            fileSystem.Directory.CreateDirectory(directory);
            return fileSystem.File.Create(path);
        }

        return fileSystem.File.Open(path, FileMode.OpenOrCreate);
    }
}