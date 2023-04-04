using cs2pu.plant_uml.node;

namespace cs2pu.plant_uml
{
    public class PlantUml
    {
        private readonly IReadOnlyCollection<Node> _nodes;
        public PlantUml()
        {
            _nodes = new List<Node>();
        }
        public PlantUml(List<Node> nodes)
        {
            _nodes = nodes;
        }

        public PlantUml Add(Node node)
        {
            return new PlantUml(new List<Node>() { node });
        }
        public PlantUml Add(PlantUml pu)
        {
            var nodes = new List<Node>();
            nodes.AddRange(_nodes);
            nodes.AddRange(pu._nodes);
            return new PlantUml(nodes);
        }

        public override string ToString()
        {
            string text = string.Empty;
            text += "@startuml class\n";
            foreach (var node in _nodes)
            {
                text += $"{node.ToString()}\n";
            }
            text += "@enduml\n";
            return text;
        }
    }
}