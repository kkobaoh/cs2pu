using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Interface : INode
    {
        public string Name { get; }

        public Accessibility Accessibility { get; }
        private readonly IReadOnlyCollection<INode> _nodes;

        public Interface(string name, Accessibility accessibility, IReadOnlyCollection<INode> nodes)
        {
            Name = name;
            Accessibility = accessibility;
            _nodes = nodes;
        }

        public string Serialize()
        {
            var str = string.Empty;
            str += $"interface {Name}{{\n";
            foreach (var node in _nodes)
            {
                str += $"\t{node.Serialize()}\n";
            }
            str += "}\n";
            return str;
        }
    }
}