using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class LambdaValueNode : ValueNode {
    public ValueNode[] Args { get; }
    public ValueNode Expr { get; }

    public LambdaValueNode(ValueNode[] args,  ValueNode expr) : base(null) {
        Args = args;
        Expr = expr;
        Children = new List<IASTNode> { expr };
    }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()})";
}