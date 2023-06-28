using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class FuncBodyNode : ASTNode
{
    public FuncBodyNode(ValueNode @return, params LetDeclNode[] letNodes)
    {
        Return = @return;
        LetNodes = letNodes;
        Children = new List<IASTNode> { @return }.Union(LetNodes).ToList();
    }

    public ValueNode Return { get; }

    public LetDeclNode[] LetNodes { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {LetNodes.AsString()} {Return.ToStringTree()})";
}