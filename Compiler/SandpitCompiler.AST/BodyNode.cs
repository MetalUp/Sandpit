namespace SandpitCompiler.AST;

public class BodyNode : ASTNode {
    public BodyNode(params VarDeclNode[] varNodes) => VarNodes = varNodes;

    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}