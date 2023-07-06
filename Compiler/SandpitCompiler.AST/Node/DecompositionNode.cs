using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class DecompositionNode : ValueNode {
    public DecompositionNode(ValueNode[] values) : base(null) => Values = values;

    public ValueNode[] Values { get; }

    public override IList<IASTNode> Children => Values.OfType<IASTNode>() .ToList();
    public override string ToStringTree() => ToString();
}