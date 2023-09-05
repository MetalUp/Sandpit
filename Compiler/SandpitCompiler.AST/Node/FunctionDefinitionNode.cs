using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class FunctionDefinitionNode : ASTNode, IFunction {
    public FunctionDefinitionNode(ValueNode id, TypeNode type, ParameterDefinitionNode[] parameters, AggregateNode<IStatement> functionBlock, IExpression returnExpression) {
        ID = id;
        Type = type;
        ReturnExpression = returnExpression;
        Parameters = parameters;
        FunctionBlock = functionBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(functionBlock.Nodes).Append(returnExpression).ToList();
    }

    public TypeNode Type { get; }
    public IExpression ReturnExpression { get; }
    public ParameterDefinitionNode[] Parameters { get; }
    public IList<IStatement> FunctionBlock { get; }

    public ValueNode ID { get; }

    public string Id => ID.Text;
    public ISymbolType? SymbolType => Type.SymbolType;

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Type.ToStringTree()} {FunctionBlock.AsString()} {ReturnExpression.ToStringTree()})";
}