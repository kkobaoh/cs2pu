using cs2pu.plant_uml.node;

namespace cs2pu.plant_uml
{
    public class Relationship
    {
        private readonly RelationType _type;
        private readonly Node _dependentNode;

        public Relationship
        (
            RelationType type,
            Node dependentNode
        )
        {
            _type = type;
            _dependentNode = dependentNode;
        }
    }
}