using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public class Method : INode
    {
        public string Name { get; }

        public Accessibility Accessibility { get; }

        private readonly IReadOnlyCollection<Parameter> _parameters;

        private readonly string _returnType;

        public Method(string name, Accessibility accessibility, IReadOnlyCollection<Parameter> parameters, string returnType)
        {
            Name = name;
            Accessibility = accessibility;
            _parameters = parameters;
            _returnType = returnType;
        }

        public string Serialize()
        {
            string str = string.Empty;

            str += $"{Accessibility.Serialize()}{_returnType} {Name}(";
            foreach (var parameter in _parameters)
            {
                str += parameter.Serialize();
                str += _parameters.Last().Equals(parameter) ? string.Empty : ", ";
            }
            str += ")";
            return str;
        }
    }
}