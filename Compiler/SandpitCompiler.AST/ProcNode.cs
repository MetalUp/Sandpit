namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(params ASTNode[] varNodes) => VarNodes = varNodes.CheckType<VarDeclNode>();

    private VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}