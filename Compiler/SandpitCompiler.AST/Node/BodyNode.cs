using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class BodyNode : ASTNode
{
    public BodyNode(params StatNode[] statNodes) => Children = StatNodes = statNodes;
    public StatNode[] StatNodes { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {StatNodes.AsString()})";
}