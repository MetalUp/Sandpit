using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class FunctionCallValueNode : ValueNode {
    public FunctionCallValueNode(ValueNode id, ValueNode[] parameters) : base(null) {
        ID = id;
        Parameters = parameters;
        Children = new List<IASTNode> { id }.Union(parameters).ToList();
    }

    public void InsertExtensionParameter(ValueNode parameter) {
        Parameters = Parameters.Prepend(parameter).ToArray();
        //Children = new List<IASTNode> { Id }.Union(Parameters).ToList(); //TODO
    }


    public ValueNode ID { get; }
    public ValueNode[] Parameters { get; private set; }

    public override IList<IASTNode> Children { get; }
    public override ISymbolType SymbolType { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}