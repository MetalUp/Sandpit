using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class TernaryExpressionNode : ASTNode, IExpression {
    public TernaryExpressionNode(IExpression control, IExpression lhs, IExpression rhs) {
        Control = control;
        Lhs = lhs;
        Rhs = rhs;
        Children = new List<IASTNode> { control, lhs, rhs };
    }

    public IExpression Control { get; }
    public IExpression Lhs { get; }
    public IExpression Rhs { get; }

    public override IList<IASTNode> Children { get; }

    public override string ToStringTree() => $"({ToString()}{Control.ToStringTree()}{Lhs.ToStringTree()}{Rhs.ToStringTree()})";
    public ISymbolType SymbolType => Lhs.SymbolType;
}