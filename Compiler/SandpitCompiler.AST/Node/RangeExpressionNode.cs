using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class RangeExpressionNode : ASTNode, IExpression {
    public RangeExpressionNode(bool prefix, IExpression from, IExpression? to) {
        Prefix = prefix;
        From = from;
        To = to;
        Children = new List<IASTNode> { from };
        if (to is not null) {
            Children = Children.Append(to).ToList();
        }
    }

    public bool Prefix { get; }
    public IExpression From { get; }
    public IExpression? To { get; }

    public override IList<IASTNode> Children { get; }

    public override string ToStringTree() => $"({ToString()}{From.ToStringTree()}{To?.ToStringTree()})";
    public ISymbolType SymbolType => throw new NotImplementedException();
}