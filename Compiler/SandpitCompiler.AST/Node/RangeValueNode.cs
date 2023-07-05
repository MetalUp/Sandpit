using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class RangeValueNode : ValueNode {
    public RangeValueNode(bool prefix, ValueNode from, ValueNode? to) : base(null) {
        Prefix = prefix;
        From = from;
        To = to;
        Children = new List<IASTNode> { from };
        if (to is not null) {
            Children = Children.Append(to).ToList();
        }
    }

    public bool Prefix { get; }
    public ValueNode From { get; }
    public ValueNode? To { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()}{From.ToStringTree()}{To?.ToStringTree()})";
}