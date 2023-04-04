using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace cs2pu.converter
{
    public class CSharpDirectory
    {
        public List<CSharpFile> Files { get; }
        public CSharpDirectory([AllowNull] string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(path);
            }
            Files = CreateFiles(path);
        }

        private List<CSharpFile> CreateFiles(string dir)
        {
            var files = new List<CSharpFile>();
            var directoryPaths = Directory.GetDirectories(dir);
            foreach (var directoryPath in directoryPaths)
            {
                files.AddRange(CreateFiles(directoryPath));
            }

            var filePaths = Directory.GetFiles(dir);
            foreach (var filePath in filePaths)
            {
                try
                {
                    files.Add(new CSharpFile(filePath));
                }
                catch (ArgumentException) { }
            }
            return files;
        }
    }
}
