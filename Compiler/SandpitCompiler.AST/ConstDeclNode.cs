namespace SandpitCompiler.AST;

public class ConstDeclNode : ASTNode {
    public ConstDeclNode(ASTNode id, ASTNode @int) {
        ID = (ValueNode)id;
        Int = (ValueNode)@int;
    }

    public ValueNode ID { get; }
    public ValueNode Int { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Int.ToStringTree()})";
}