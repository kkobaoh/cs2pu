using cs2pu.plant_uml.node;
using Microsoft.CodeAnalysis.CSharp;

namespace cs2pu.plant_uml
{
    public class Node
    {
        private readonly string _name;
        private readonly PlantUmlType _type;
        private readonly IReadOnlyCollection<Relationship> _relationships;
        private readonly IReadOnlyCollection<Content> _contents;

        public Node(string name, PlantUmlType type)
        {
            _name = name;
            _type = type;
            _relationships = new List<Relationship>();
            _contents = new List<Content>();
        }

        public Node(string name, SyntaxKind kind) : this(name, Create(kind)) { }

        private static PlantUmlType Create(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.ClassDeclaration:
                    return PlantUmlType.Class;
                case SyntaxKind.InterfaceDeclaration:
                    return PlantUmlType.Interface;
                case SyntaxKind.EnumDeclaration:
                    return PlantUmlType.Enum;
                default:
                    return PlantUmlType.Entity;
            }
        }

        public override string ToString()
        {
            string text = string.Empty;
            text += $"\t{_type.ToString()} {_name}{{\n";
            text += "\t}\n";
            return text;
        }
    }
}