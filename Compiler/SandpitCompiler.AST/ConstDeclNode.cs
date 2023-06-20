namespace SandpitCompiler.AST;

public class ConstDeclNode : ASTNode {
    public ConstDeclNode(ValueNode id, ValueNode val) {
        ID = id;
        Val = val;
        InferredType = ASTHelpers.TokenToType[val.TokenName];
    }

    public ValueNode ID { get; }
    public ValueNode Val { get; }
    public string InferredType { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Val.ToStringTree()})".TrimEnd();
}