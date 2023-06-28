using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ProcStatNode : StatNode
{
    public ProcStatNode(ValueNode id, ValueNode[] parameters)
    {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public ValueNode ID { get; }
    public ValueNode[] Parameters { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}