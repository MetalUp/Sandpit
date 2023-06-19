namespace SandpitCompiler.AST;

public class FuncNode : ASTNode {
    public FuncNode(ValueNode id, ValueNode type, ValueNode @return, ParamNode[] paramNodes, params LetDeclNode[] letNodes) {
        ID = id;
        Type = type;
        Return = @return;
        ParamNodes = paramNodes;
        LetNodes = letNodes;
    }

    public ValueNode ID { get; }
    public ValueNode Type { get; }
    public ValueNode Return { get; }
    public ParamNode[] ParamNodes { get; }
    public LetDeclNode[] LetNodes { get; }

    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()})";
}