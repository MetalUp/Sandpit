using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class VarDeclNode : StatNode, IDecl
{
    public VarDeclNode(ValueNode id, ValueNode expr)
    {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { id, expr };
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}