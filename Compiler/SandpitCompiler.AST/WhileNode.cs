namespace SandpitCompiler.AST;

public class WhileNode : StatNode {
    public WhileNode(ValueNode expr, BodyNode body) {
        Expr = expr;
        Body = body;
        Children = new List<ASTNode> { expr, body };
    }

    public ValueNode Expr { get; }
    public BodyNode Body { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Expr.ToStringTree()} {Body.ToStringTree()} )";
}