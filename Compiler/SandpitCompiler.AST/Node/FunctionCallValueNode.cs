using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class FunctionCallValueNode : ASTNode, IExpression {
    public FunctionCallValueNode(ValueNode id, IExpression[] parameters)  {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public FunctionCallValueNode(FunctionCallValueNode node, IExpression parameter) : this(node.ID, node.Parameters.Prepend(parameter).ToArray()) { }

    public void InsertExtensionParameter(IExpression parameter) {
        Parameters = Parameters.Prepend(parameter).ToArray();
        //Children = new List<IASTNode> { Id }.Union(Parameters).ToList(); //TODO
    }


    public ValueNode ID { get; }
    public IExpression[] Parameters { get; private set; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
    public ISymbolType SymbolType => throw new NotImplementedException();
}