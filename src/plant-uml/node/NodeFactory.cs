using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace cs2pu.plant_uml.node
{
    class NodeFactory
    {
        private readonly IEnumerable<CSharpSyntaxNode> _syntaxes;
        public NodeFactory(string source)
        {
            var root = CSharpSyntaxTree.ParseText(source).GetRoot();
            _syntaxes = root.DescendantNodes().OfType<CSharpSyntaxNode>();
        }
        public NodeFactory(CSharpSyntaxNode syntax)
        {
            _syntaxes = syntax.DescendantNodes().OfType<CSharpSyntaxNode>();
        }
        public NodeFactory(SyntaxList<MemberDeclarationSyntax> syntaxes)
        {
            _syntaxes = syntaxes;
        }

        public IReadOnlyCollection<INode> Create()
        {
            var nodes = new List<INode>();

            foreach (var syntax in _syntaxes)
            {
                switch (syntax.Kind())
                {
                    case SyntaxKind.ClassDeclaration:
                        nodes.Add(CreateClass(syntax as ClassDeclarationSyntax));
                        break;
                    case SyntaxKind.InterfaceDeclaration:
                        nodes.Add(CreateInterface(syntax as InterfaceDeclarationSyntax));
                        break;
                    case SyntaxKind.EnumDeclaration:
                        nodes.Add(CreateEnum(syntax as EnumDeclarationSyntax));
                        break;
                }
            }

            return nodes;
        }
        private IReadOnlyCollection<INode> CreateContent()
        {
            var nodes = new List<INode>();

            foreach (var syntax in _syntaxes)
            {
                switch (syntax.Kind())
                {
                    case SyntaxKind.MethodDeclaration:
                        nodes.Add(CreateMethod(syntax as MethodDeclarationSyntax));
                        break;
                    case SyntaxKind.PropertyDeclaration:
                        nodes.Add(CreateProperty(syntax as PropertyDeclarationSyntax));
                        break;
                }
            }

            return nodes;
        }

        private Class CreateClass([AllowNull] ClassDeclarationSyntax syntax)
        {
            if (syntax is null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }
            var name = syntax.Identifier.Text;
            var accessibility = new Accessibility(syntax.Modifiers.FirstOrDefault().Text);
            var factory = new NodeFactory(syntax.Members);

            return new Class(name, accessibility, factory.CreateContent());
        }

        private Interface CreateInterface([AllowNull] InterfaceDeclarationSyntax syntax)
        {
            if (syntax is null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }
            var name = syntax.Identifier.Text;
            var accessibility = new Accessibility(syntax.Modifiers.FirstOrDefault().Text);
            var factory = new NodeFactory(syntax.Members);

            return new Interface(name, accessibility, factory.CreateContent());
        }

        private Enum CreateEnum([AllowNull] EnumDeclarationSyntax syntax)
        {
            if (syntax is null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }

            var name = syntax.Identifier.Text;
            var members = new List<string>();
            var accessibility = new Accessibility(syntax.Modifiers.FirstOrDefault().Text);

            foreach (var memberDeclarationSyntax in syntax.Members)
            {
                members.Add(memberDeclarationSyntax.Identifier.Text);
            }

            return new Enum(name, accessibility, members);
        }

        private Method CreateMethod([AllowNull] MethodDeclarationSyntax syntax)
        {
            if (syntax is null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }
            var name = syntax.Identifier.Text;

            var accessibility = new Accessibility(syntax.Modifiers.FirstOrDefault().Text);
            var returnType = (syntax.ReturnType as IdentifierNameSyntax)?.Identifier.Text ?? "void";
            var parameters = new List<Parameter>();
            foreach (var parameterSyntax in syntax.ParameterList.Parameters)
            {
                var parameterName = parameterSyntax.Identifier.Text;
                var parameterType = (parameterSyntax.Type as IdentifierNameSyntax)?.Identifier.Text ?? parameterSyntax.Type?.ToString() ?? string.Empty;
                var parameter = new Parameter(parameterName, parameterType);

                parameters.Add(parameter);
            }
            return new Method(name, accessibility, parameters, returnType);
        }

        private Property CreateProperty([AllowNull] PropertyDeclarationSyntax syntax)
        {
            if (syntax is null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }
            var name = syntax.Identifier.Text;

            var accessibility = new Accessibility(syntax.Modifiers.FirstOrDefault().Text);
            var type = (syntax.Type as IdentifierNameSyntax)?.Identifier.Text ?? "void";

            return new Property(name, accessibility, type);
        }
    }
}