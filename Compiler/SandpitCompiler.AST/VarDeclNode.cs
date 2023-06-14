namespace SandpitCompiler.AST;

public class VarDeclNode : ASTNode {
    public VarDeclNode(ASTNode id, ASTNode expr) {
        ID = (ValueNode)id;
        Expr = (ValueNode)expr;
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}