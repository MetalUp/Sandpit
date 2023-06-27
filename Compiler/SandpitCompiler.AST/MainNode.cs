namespace SandpitCompiler.AST;

public class MainNode : ASTNode {
    public MainNode(BodyNode body) {
        Body = body;
        Children = new List<ASTNode> { body };
    }

    public BodyNode Body { get; }
    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Body.ToStringTree()})".TrimEnd();
}