namespace SandpitCompiler.AST;

public class WhileNode : ASTNode {
    public WhileNode() { }

    public override string ToStringTree() => $"({ToString()} )";
}