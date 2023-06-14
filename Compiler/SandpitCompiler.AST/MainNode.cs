namespace SandpitCompiler.AST;

public class MainNode : ASTNode {
    public MainNode(IEnumerable<ASTNode> varNodes) => VarNodes = varNodes.CheckType<VarDeclNode>();

    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() {
        return $"({ToString()} {VarNodes.AsString()})".TrimEnd();
    }
}