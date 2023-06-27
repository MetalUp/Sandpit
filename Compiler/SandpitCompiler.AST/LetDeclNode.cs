namespace SandpitCompiler.AST;

public class LetDeclNode : ASTNode {
    public LetDeclNode(ValueNode id, ValueNode expr) {
        ID = id;
        Expr = expr;
        Children = new List<ASTNode>() { ID, Expr };
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}