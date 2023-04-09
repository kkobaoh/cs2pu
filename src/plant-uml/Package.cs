using System.Diagnostics.CodeAnalysis;
using cs2pu.plant_uml.node;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace cs2pu.plant_uml
{
    public class Package
    {
        public string Name { get; }
        public IReadOnlyCollection<INode> Nodes { get; }

        public Accessibility Accessibility { get; }

        public Package(string source)
        {
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = tree.GetRoot();
            var nodes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>();
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public INode Create(string source)
        {
            throw new NotImplementedException();
        }
    }
}