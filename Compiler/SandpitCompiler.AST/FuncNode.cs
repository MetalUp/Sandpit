namespace SandpitCompiler.AST;

public class FuncNode : ASTNode {
    public FuncNode(ValueNode id, ValueNode type, ParamNode[] paramNodes, params LetDeclNode[] letNodes) {
        ID = id;
        Type = type;
        ParamNodes = paramNodes;
        LetNodes = letNodes;
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }
    public ParamNode[] ParamNodes { get; }
    public LetDeclNode[] LetNodes { get; }

    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()})";
}