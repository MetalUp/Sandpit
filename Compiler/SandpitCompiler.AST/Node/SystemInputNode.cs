using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class SystemInputNode : IASTNode, IStatement {
    public IValue ID { get; }

    public SystemInputNode(IValue id,  IExpression toPrint, bool line) {
        this.ID = id;
        ToPrint = toPrint;
        Line = line;
        Children = new List<IASTNode>() { ToPrint };
    }

    public IExpression ToPrint { get; }
    public bool Line { get; }
    public IList<IASTNode> Children { get; }
    public string ToStringTree() => $"({ToString()}{ToPrint.ToStringTree()})";
    public ISymbolType SymbolType  => new BuiltInType("String"); // TODO 
}