namespace SandpitCompiler.AST;

public class FuncNode : ASTNode {
    public FuncNode(ValueNode id, params LetDeclNode[] letNodes) {
        ID = id;
        LetNodes = letNodes;
    }

    public ValueNode ID { get; }
    public LetDeclNode[] LetNodes { get; }

    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()})";
}