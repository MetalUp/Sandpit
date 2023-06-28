using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ProcNode : ASTNode, IProc
{
    public ProcNode(ValueNode id, ParamNode[] parameters, BodyNode body)
    {
        ID = id;
        Parameters = parameters;
        Body = body;
        Children = new List<IASTNode> { id, body }.Union(parameters).ToList();
    }

    public ValueNode ID { get; }
    public ParamNode[] Parameters { get; }
    public BodyNode Body { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Body})";
}