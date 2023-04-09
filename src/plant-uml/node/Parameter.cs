using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Parameter
    {
        public string Name { get; }
        public string Type { get; }

        public Parameter(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public string Serialize()
        {
            var str = string.Empty;
            str += $"{Type} {Name}";
            return str;
        }
    }
}