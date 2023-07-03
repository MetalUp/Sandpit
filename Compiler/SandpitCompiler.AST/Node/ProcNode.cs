using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ProcNode : ASTNode, IProc {
    public ProcNode(ValueNode id, ParamNode[] parameters, AggregateNode<StatNode> procedureBlock) {
        ID = id;
        Parameters = parameters;
        ProcedureBlock = procedureBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(procedureBlock.Nodes).ToList();
    }

    public ParamNode[] Parameters { get; }
    public IList<StatNode> ProcedureBlock { get; }

    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {ProcedureBlock.AsString()})";
}