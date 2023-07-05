using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class IndexValueNode : ValueNode {
    public IndexValueNode(ValueNode expr, ValueNode index) :base(null) {
        Expr = expr;
        Index = index;

        Children = new List<IASTNode> { expr, index };
    }

    public ValueNode Expr { get; }
    public ValueNode Index { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()}{Index.ToStringTree()})";
}