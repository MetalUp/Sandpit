using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class FuncDefnNode : ASTNode, IProc {
    public FuncDefnNode(ValueNode id, TypeNode type, ParamDefnNode[] parameters, AggregateNode<StatNode> functionBlock, ValueNode returnExpression) {
        ID = id;
        Type = type;
        ReturnExpression = returnExpression;
        Parameters = parameters;
        FunctionBlock = functionBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(functionBlock.Nodes).Append(returnExpression).ToList();
    }

    public TypeNode Type { get; }
    public ValueNode ReturnExpression { get; }
    public ParamDefnNode[] Parameters { get; }
    public IList<StatNode> FunctionBlock { get; }

    public ValueNode ID { get; }
    public ISymbolType? SymbolType => Type.SymbolType;

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Type.ToStringTree()} {FunctionBlock.AsString()} {ReturnExpression.ToStringTree()})";
}