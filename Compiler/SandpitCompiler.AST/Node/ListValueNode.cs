using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ListValueNode : ValueNode {
    public ListValueNode(params ValueNode[] valueNodes) : base(valueNodes.Any() ? valueNodes.First().Token : null) => Children = ValueNodes = valueNodes;

    public ValueNode[] ValueNodes { get; }

    public string[] Texts => ValueNodes.Select(vn => vn.Text).ToArray();

    public override IList<IASTNode> Children { get; }

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}