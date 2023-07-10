using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class ProcedureDefinitionNode : ASTNode, IProcedure {
    public ProcedureDefinitionNode(ValueNode id, ParameterDefinitionNode[] parameters, AggregateNode<IStatement> procedureBlock) {
        ID = id;
        Parameters = parameters;
        ProcedureBlock = procedureBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(procedureBlock.Nodes).ToList();
    }

    public ParameterDefinitionNode[] Parameters { get; }
    public IList<IStatement> ProcedureBlock { get; }

    public ValueNode ID { get; }
    public ISymbolType? SymbolType => null;

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {ProcedureBlock.AsString()})";
}