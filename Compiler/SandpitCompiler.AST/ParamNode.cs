namespace SandpitCompiler.AST;

public class ParamNode : ASTNode {
    public ParamNode(ValueNode id, ValueNode type) {
        ID = id;
        Type = type;
        Children = new List<ASTNode> { id, type };
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Type.ToStringTree()})";
}