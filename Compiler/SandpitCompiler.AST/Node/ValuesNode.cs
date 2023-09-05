using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ValuesNode : ASTNode, IValue {
    public ValuesNode(ValueNode[] values) {
        Values = values;
        Children = Values.OfType<IASTNode>().ToList();
    }

    public ValueNode[] Values { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => throw new NotImplementedException();
    public string Text => ""; // TODO what should this be ? 
}