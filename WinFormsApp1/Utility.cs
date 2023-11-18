using System.IO.Abstractions;

namespace WinFormsApp1
{
    internal static class Utility
    {
        public static readonly IFileSystem Filesystem = new FileSystem();
        
    }
}
