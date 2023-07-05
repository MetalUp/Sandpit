using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class TupleTypeNode : TypeNode {
    public TupleTypeNode(IEnumerable<TypeNode> items) : base(null) => Items = items.ToList();

    public IList<TypeNode> Items { get; }

    public override IList<IASTNode> Children => Items.OfType<IASTNode>().ToList();
    public override string ToStringTree() => ToString();
}