using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class WhileNode : StatNode
{
    public WhileNode(ValueNode expr, BodyNode body)
    {
        Expr = expr;
        Body = body;
        Children = new List<IASTNode> { expr, body };
    }

    public ValueNode Expr { get; }
    public BodyNode Body { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Expr.ToStringTree()} {Body.ToStringTree()} )";
}