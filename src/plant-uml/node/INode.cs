using System.Diagnostics.CodeAnalysis;

namespace cs2pu.plant_uml.node
{
    public interface INode
    {
        string Name { get; }

        Accessibility Accessibility { get; }

        string Serialize();
    }
}