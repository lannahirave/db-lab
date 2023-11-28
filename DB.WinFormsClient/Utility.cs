using System.IO.Abstractions;

namespace DB.WinFormsClient;

internal static class Utility
{
    public static readonly IFileSystem Filesystem = new FileSystem();
}