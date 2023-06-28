using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class MainNode : ASTNode, IBlock
{
    public MainNode(BodyNode body)
    {
        Body = body;
        Children = new List<IASTNode> { body };
    }

    public BodyNode Body { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Body.ToStringTree()})".TrimEnd();
}