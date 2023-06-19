namespace SandpitCompiler.AST;

public class MainNode : ASTNode {
    public MainNode(params VarDeclNode[] varNodes) => VarNodes = varNodes;

    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() {
        return $"({ToString()} {VarNodes.AsString()})".TrimEnd();
    }
}