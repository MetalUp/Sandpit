using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ProcedureStatementNode : ASTNode, IStatement {
    public ProcedureStatementNode(ValueNode id, IExpression[] parameters) {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public ValueNode ID { get; }
    public IExpression[] Parameters { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}