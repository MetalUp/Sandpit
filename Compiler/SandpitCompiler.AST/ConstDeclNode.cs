namespace SandpitCompiler.AST;

public class ConstDeclNode : ASTNode {
    public ConstDeclNode(ValueNode id, ValueNode @int) {
        ID = id;
        Int = @int;
    }

    public ValueNode ID { get; }
    public ValueNode Int { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Int.ToStringTree()})".TrimEnd();
}