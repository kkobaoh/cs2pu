using cs2pu.plant_uml.node;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace cs2pu.plant_uml
{
    public class PlantUml
    {
        private readonly IReadOnlyCollection<INode> _nodes;
        public static PlantUml Empty => new PlantUml(new List<INode>());

        private PlantUml(List<INode> nodes)
        {
            _nodes = nodes;
        }

        public PlantUml Add(IReadOnlyCollection<INode> nodes)
        {
            var addedNodes = new List<INode>(nodes);
            addedNodes.AddRange(_nodes);
            return new PlantUml(addedNodes);
        }

        public string Serialize()
        {
            string text = string.Empty;
            text += "@startuml class_diagram\n";
            foreach (var node in _nodes)
            {
                text += $"{node.Serialize()}\n";
            }
            text += "@enduml\n";
            return text;
        }
    }
}