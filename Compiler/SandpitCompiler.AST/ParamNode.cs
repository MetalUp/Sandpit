namespace SandpitCompiler.AST;

public class ParamNode : ASTNode {
    public ParamNode(ValueNode id, ValueNode type) {
        ID = id;
        Type = type;
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Type.ToStringTree()})";
}