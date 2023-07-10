using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class FunctionExpressionNode : ASTNode, IExpression {
    public FunctionExpressionNode(ValueNode id, IExpression[] parameters) {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public FunctionExpressionNode(FunctionExpressionNode node, IExpression parameter) : this(node.ID, node.Parameters.Prepend(parameter).ToArray()) { }

    public ValueNode ID { get; }
    public IExpression[] Parameters { get; private set; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
    public ISymbolType SymbolType => throw new NotImplementedException();

    public void InsertExtensionParameter(IExpression parameter) {
        Parameters = Parameters.Prepend(parameter).ToArray();
        //Children = new List<IASTNode> { Id }.Union(Parameters).ToList(); //TODO
    }
}