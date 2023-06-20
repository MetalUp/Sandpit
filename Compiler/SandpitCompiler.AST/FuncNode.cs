namespace SandpitCompiler.AST;

public class FuncNode : ASTNode {
    public FuncNode(ValueNode id, ValueNode type, ParamNode[] paramNodes, FuncBodyNode body) {
        ID = id;
        Type = type;
        ParamNodes = paramNodes;
        Body = body;
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }
    public ParamNode[] ParamNodes { get; }
    public FuncBodyNode Body { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {ParamNodes.AsString()} {Type.ToStringTree()} {Body.ToStringTree()})";
}