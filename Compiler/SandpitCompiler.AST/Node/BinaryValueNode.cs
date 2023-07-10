using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class BinaryValueNode : ValueNode {
    public BinaryValueNode(OperatorValueNode op, ValueNode lhs, ValueNode rhs) : base(op.Token) {
        Op = op;
        Lhs = lhs;
        Rhs = rhs;
        Children = new List<IASTNode> { op, lhs, rhs };
    }

    public OperatorValueNode Op { get; }
    public ValueNode Lhs { get; }
    public ValueNode Rhs { get; }

    public override IList<IASTNode> Children { get; }
    public override ISymbolType SymbolType { get; }
    public override string ToStringTree() => $"({ToString()}{Op.ToStringTree()}{Lhs.ToStringTree()}{Rhs.ToStringTree()})";
}