using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Property : INode
    {
        public string Name { get; }

        public Accessibility Accessibility { get; }

        public string Type { get; }

        public Property(string name, Accessibility accessibility, string type)
        {
            Name = name;
            Accessibility = accessibility;
            Type = type;
        }
        public string Serialize()
        {
            var str = string.Empty;
            str += $"{Accessibility.Serialize()}{Type} {Name}";
            return str;
        }
    }
}