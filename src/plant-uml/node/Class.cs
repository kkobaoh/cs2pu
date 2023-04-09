using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Class : INode
    {
        public string Name { get; }

        public Accessibility Accessibility { get; }

        private readonly IReadOnlyCollection<INode> _nodes;
        public Class(string name, Accessibility accessibility, IReadOnlyCollection<INode> nodes)
        {
            Name = name;
            Accessibility = accessibility;
            _nodes = nodes;
        }

        public string Serialize()
        {
            var str = string.Empty;
            str += $"class {Name}{{\n";
            foreach (var node in _nodes)
            {
                str += $"\t{node.Serialize()}\n";
            }
            str += "}\n";
            return str;
        }
    }
}
