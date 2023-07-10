using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class WhileStatementNode : ASTNode, IStatement {
    public WhileStatementNode(IExpression condition, AggregateNode<IStatement> procedureBlock) {
        Condition = condition;
        ProcedureBlock = procedureBlock.Nodes;
        Children = new List<IASTNode> { condition }.Union(procedureBlock.Nodes).ToList();
    }

    public IList<IStatement> ProcedureBlock { get; }

    public IExpression Condition { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Condition.ToStringTree()} {ProcedureBlock.AsString()} )";
}