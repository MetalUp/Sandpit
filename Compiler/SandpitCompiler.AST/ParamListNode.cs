namespace SandpitCompiler.AST;

public class ParamListNode : ASTNode {
    public ParamListNode(ValueNode id, params VarDeclNode[] varNodes) {
        ID = id;
        VarNodes = varNodes;
        Children = new List<ASTNode>() { id }.Union(varNodes).ToList();
    }

    public ValueNode ID { get; }
    public VarDeclNode[] VarNodes { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}