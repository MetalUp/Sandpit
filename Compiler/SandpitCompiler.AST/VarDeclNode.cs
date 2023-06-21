namespace SandpitCompiler.AST;

public class VarDeclNode : StatNode {
    public VarDeclNode(ValueNode id, ValueNode expr) {
        ID = id;
        Expr = expr;
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}