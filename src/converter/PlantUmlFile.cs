using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using cs2pu.plant_uml;

namespace cs2pu.converter
{
    public class PlantUmlFile
    {
        [DisallowNull]
        private readonly string _path;

        public PlantUmlFile([AllowNull] string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            _path = path;
        }

        public void Save(PlantUml pu)
        {
            using (var stream = new StreamWriter(_path, false, Encoding.UTF8))
            {
                stream.Write(pu.Serialize());
            }
        }
    }
}