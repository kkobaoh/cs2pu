using cs2pu.plant_uml;
using cs2pu.plant_uml.node;

namespace cs2pu.converter
{
    public class Converter
    {
        internal PlantUml Execute(CSharpDirectory csDirectory)
        {
            var pu = PlantUml.Empty;
            foreach (var file in csDirectory.Files)
            {
                var source = file.Read();

                var factory = new NodeFactory(source);
                var nodes = factory.Create();

                pu = pu.Add(nodes);
            }
            return pu;
        }
    }
}