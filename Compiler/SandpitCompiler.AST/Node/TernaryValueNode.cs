using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class TernaryValueNode : ValueNode {
    public TernaryValueNode(ValueNode control, ValueNode lhs, ValueNode rhs) : base(null) {
        Control = control;
        Lhs = lhs;
        Rhs = rhs;
        Children = new List<IASTNode> { control, lhs, rhs };
    }

    public ValueNode Control { get; }
    public ValueNode Lhs { get; }
    public ValueNode Rhs { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()}{Control.ToStringTree()}{Lhs.ToStringTree()}{Rhs.ToStringTree()})";
}