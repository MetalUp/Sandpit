using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LambdaExpressionNode : ASTNode, IExpression {
    public LambdaExpressionNode(ValueNode[] args, IExpression expr) {
        Args = args;
        Expr = expr;
        Children = new List<IASTNode> { expr };
    }

    public ValueNode[] Args { get; }
    public IExpression Expr { get; }

    public override IList<IASTNode> Children { get; }

    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()})";
    public ISymbolType SymbolType => Expr.SymbolType;
}