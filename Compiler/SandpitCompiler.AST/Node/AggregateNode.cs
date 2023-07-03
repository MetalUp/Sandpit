using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class AggregateNode<T> : ASTNode where T : IASTNode {
    public AggregateNode(IEnumerable<T> children) => Nodes = children.ToList();

    public IList<T> Nodes { get; }

    public override IList<IASTNode> Children => Nodes.OfType<IASTNode>().ToList();
    public override string ToStringTree() => throw new NotImplementedException();
}