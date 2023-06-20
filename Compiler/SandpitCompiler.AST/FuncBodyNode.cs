namespace SandpitCompiler.AST;

public class FuncBodyNode : ASTNode {
    public FuncBodyNode(ValueNode @return, params LetDeclNode[] letNodes) {
        Return = @return;
        LetNodes = letNodes;
    }

    public ValueNode Return { get; }

    public LetDeclNode[] LetNodes { get; }

    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()} {Return.ToStringTree()})";
}