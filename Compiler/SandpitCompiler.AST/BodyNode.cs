namespace SandpitCompiler.AST;

public class BodyNode : ASTNode {
    public BodyNode(params StatNode[] statNodes) => Children = StatNodes = statNodes;
    public StatNode[] StatNodes { get; }
    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {StatNodes.AsString()})";
}