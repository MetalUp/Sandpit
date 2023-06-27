namespace SandpitCompiler.AST;

public class FuncBodyNode : ASTNode {
    public FuncBodyNode(ValueNode @return, params LetDeclNode[] letNodes) {
        Return = @return;
        LetNodes = letNodes;
        Children = new List<ASTNode> { @return }.Union(LetNodes).ToList();
    }

    public ValueNode Return { get; }

    public LetDeclNode[] LetNodes { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()} {Return.ToStringTree()})";
}