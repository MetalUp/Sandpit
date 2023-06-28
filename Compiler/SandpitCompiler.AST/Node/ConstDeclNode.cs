using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ConstDeclNode : ASTNode, IDecl
{
    public ConstDeclNode(ValueNode id, ValueNode val)
    {
        ID = id;
        Val = val;
        InferredType = ASTHelpers.TokenToType(val.TokenName);
        Children = new List<IASTNode> { ID, Val };
    }

    public ValueNode ID { get; }
    public ValueNode Val { get; }
    public string InferredType { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Val.ToStringTree()})".TrimEnd();
}