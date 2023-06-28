using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class LetDeclNode : ASTNode, IDecl
{
    public LetDeclNode(ValueNode id, ValueNode expr)
    {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode>() { ID, Expr };
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}