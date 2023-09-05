using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class MethodStatementNode : ASTNode, IStatement, IExpression {
    public MethodStatementNode(ValueNode id, IExpression[] parameters) {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
        SymbolType = new UnresolvedType(ID.Text);
    }

    public MethodStatementNode(MethodStatementNode node, IExpression parameter) : this(node.ID, node.Parameters.Prepend(parameter).ToArray()) { }

    public ValueNode ID { get; }
    public IExpression[] Parameters { get; }
    public ISymbolType SymbolType { get; set; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}