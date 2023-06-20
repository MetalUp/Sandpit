namespace SandpitCompiler.AST;

public class ListNode : ASTNode {
    public ValueNode[] ValueNodes { get; }
    public ListNode(params ValueNode[] valueNodes) {
        ValueNodes = valueNodes;
    }

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}