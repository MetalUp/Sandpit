namespace SandpitCompiler.AST;

public class ListNode : ValueNode {
    public ListNode(params ValueNode[] valueNodes) : base(valueNodes.Any() ? valueNodes.First().Token : null) => ValueNodes = valueNodes;

    private ValueNode[] ValueNodes { get; }

    public string[] Texts => ValueNodes.Select(vn => vn.Text).ToArray();

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}