namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ASTNode id, params ASTNode[] varNodes) {
        ID = id;
        VarNodes = varNodes.CheckType<VarDeclNode>();
    }

    public ASTNode ID { get; }
    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}