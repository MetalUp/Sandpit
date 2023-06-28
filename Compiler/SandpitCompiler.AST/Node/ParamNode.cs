using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ParamNode : ASTNode, IDecl
{
    public ParamNode(ValueNode id, ValueNode type)
    {
        ID = id;
        Type = type;
        Children = new List<IASTNode> { id, type };
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Type.ToStringTree()})";
}