using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class SystemPrintNode : IASTNode, IStatement {
    public SystemPrintNode(IExpression toPrint, bool line) {
        ToPrint = toPrint;
        Line = line;
        Children = new List<IASTNode>() { ToPrint };
    }

    public IExpression ToPrint { get; }
    public bool Line { get; }
    public IList<IASTNode> Children { get; }
    public string ToStringTree() => $"({ToString()}{ToPrint.ToStringTree()})";
}