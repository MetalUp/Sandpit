using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class MainNode : ASTNode, IBlock {
    public MainNode(AggregateNode<StatNode> procedureBlock) {
        ProcedureBlock = procedureBlock.Nodes;
        Children = procedureBlock.Children;
    }

    public IList<StatNode> ProcedureBlock { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ProcedureBlock.AsString()})".TrimEnd();
}