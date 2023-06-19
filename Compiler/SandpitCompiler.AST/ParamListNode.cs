namespace SandpitCompiler.AST;

public class ParamListNode : ASTNode {
    public ParamListNode(ValueNode id, params VarDeclNode[] varNodes) {
        ID = id;
        VarNodes = varNodes;
    }

    public ValueNode ID { get; }
    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}