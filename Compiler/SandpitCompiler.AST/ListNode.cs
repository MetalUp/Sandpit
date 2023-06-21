namespace SandpitCompiler.AST;

public class ListNode : ValueNode {
    public ListNode(params ValueNode[] valueNodes) : base(valueNodes[0]?.Token) => ValueNodes = valueNodes;

    public ValueNode[] ValueNodes { get; }

    public string[] Texts => ValueNodes.Select(vn => vn.Text).ToArray();

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}