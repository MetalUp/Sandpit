namespace SandpitCompiler.AST;

public class BinaryOperatorNode : ValueNode {
    public BinaryOperatorNode(ValueNode op, ValueNode lhs, ValueNode rhs) : base(op.Token) {
        Op = op;
        Lhs = lhs;
        Rhs = rhs;
    }

    public ValueNode Op { get; }
    public ValueNode Lhs { get; }
    public ValueNode Rhs { get; }

    public override string ToStringTree() => $"({ToString()}{Lhs.ToStringTree()}{Rhs.ToStringTree()})";
}