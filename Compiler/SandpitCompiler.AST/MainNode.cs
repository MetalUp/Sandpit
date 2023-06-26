namespace SandpitCompiler.AST;

public class MainNode : ASTNode {
    public MainNode(BodyNode body) => Body = body;

    public BodyNode Body { get; }

    public override string ToStringTree() => $"({ToString()} {Body.ToStringTree()})".TrimEnd();
}