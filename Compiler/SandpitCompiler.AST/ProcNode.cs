namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ValueNode id, params VarDeclNode[] varNodes) {
        ID = id;
        VarNodes = varNodes;
    }

    public ValueNode ID { get; }
    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}