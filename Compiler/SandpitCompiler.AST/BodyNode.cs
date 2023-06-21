namespace SandpitCompiler.AST;

public class BodyNode : ASTNode {
    public BodyNode(params StatNode[] statNodes) => StatNodes = statNodes;

    public StatNode[] StatNodes { get; }

    public override string ToStringTree() => $"({ToString()} {StatNodes.AsString()})";
}