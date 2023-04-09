using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Enum : INode
    {
        public string Name { get; }

        public Accessibility Accessibility { get; }

        private readonly IReadOnlyCollection<string> _members;

        public Enum(string name, Accessibility accessibility, IReadOnlyCollection<string> members)
        {
            Name = name;
            Accessibility = accessibility;
            _members = members;
        }

        public string Serialize()
        {
            var str = string.Empty;
            str += $"enum {Name}{{\n";
            foreach (var member in _members)
            {
                str += $"\t{member}\n";
            }
            str += "}\n";
            return str;
        }
    }
}