using cs2pu.plant_uml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace cs2pu.converter
{
    public class Converter
    {

        internal PlantUml Execute(CSharpDirectory csDirectory)
        {
            var pu = new PlantUml();
            foreach (var file in csDirectory.Files)
            {
                var source = file.Read();
                var tree = CSharpSyntaxTree.ParseText(source);
                var root = tree.GetRoot();
                var nodes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
                pu = pu.Add(CreatePlantUml(nodes));
            }
            return pu;
        }

        public PlantUml CreatePlantUml(IEnumerable<BaseTypeDeclarationSyntax> nodes)
        {
            var pu = new PlantUml();
            foreach (var node in nodes)
            {
                var name = node.Identifier.Text;
                var kind = node.Kind();

                var puNode = new Node(name, kind);
                pu = pu.Add(puNode);
            }
            return pu;
        }
    }
}