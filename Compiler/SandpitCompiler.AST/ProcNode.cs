namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ValueNode id, ParamNode[] paramNodes, params VarDeclNode[] varNodes) {
        ID = id;
        ParamNodes = paramNodes;
        VarNodes = varNodes;
    }

    public ValueNode ID { get; }
    public ParamNode[] ParamNodes { get; }
    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {ParamNodes.AsString()} {VarNodes.AsString()})";
}