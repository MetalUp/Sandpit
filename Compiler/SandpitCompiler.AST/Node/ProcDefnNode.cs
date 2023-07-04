using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ProcDefnNode : ASTNode, IProc {
    public ProcDefnNode(ValueNode id, ParamDefnNode[] parameters, AggregateNode<StatNode> procedureBlock) {
        ID = id;
        Parameters = parameters;
        ProcedureBlock = procedureBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(procedureBlock.Nodes).ToList();
    }

    public ParamDefnNode[] Parameters { get; }
    public IList<StatNode> ProcedureBlock { get; }

    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {ProcedureBlock.AsString()})";
}