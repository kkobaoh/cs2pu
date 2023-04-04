using System.Diagnostics.CodeAnalysis;

namespace cs2pu.converter
{
    public class CSharpFile
    {
        private readonly string _path;

        public CSharpFile([AllowNull] string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            if(path.Substring(path.Length-3) != ".cs")
            {
                throw new ArgumentException($"{path} is not C# file.");
            }
            _path = path;
        }

        public string Read()
        {
            var source = File.ReadAllText(_path);
            return source;
        }
    }
}