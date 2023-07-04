using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class FuncNode : ASTNode, IProc {
    public FuncNode(ValueNode id, ValueNode type, ParamNode[] parameters, AggregateNode<StatNode> functionBlock, ValueNode returnExpression) {
        ID = id;
        Type = type;
        ReturnExpression = returnExpression;
        Parameters = parameters;
        FunctionBlock = functionBlock.Nodes;
        Children = new List<IASTNode> { id }.Union(parameters).Union(functionBlock.Nodes).Append(returnExpression).ToList();
    }

    public ValueNode Type { get; }
    public ValueNode ReturnExpression { get; }
    public ParamNode[] Parameters { get; }
    public IList<StatNode> FunctionBlock { get; }

    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Type.ToStringTree()} {FunctionBlock.AsString()} {ReturnExpression.ToStringTree()})";
}