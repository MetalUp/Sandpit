using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class MethodStatementNode : ASTNode, IStatement, IExpression {
    public MethodStatementNode(ValueNode id, IExpression[] parameters) {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public MethodStatementNode(MethodStatementNode node, IExpression parameter) : this(node.ID, node.Parameters.Prepend(parameter).ToArray()) { }

    public ValueNode ID { get; }
    public IExpression[] Parameters { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
    public ISymbolType SymbolType => new UnresolvedType(ID.Text);
}