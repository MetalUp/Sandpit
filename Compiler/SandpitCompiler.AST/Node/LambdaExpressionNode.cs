using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LambdaExpressionNode : ASTNode, IExpression {
    public ValueNode[] Args { get; }
    public IExpression Expr { get; }

    public LambdaExpressionNode(ValueNode[] args,  IExpression expr) {
        Args = args;
        Expr = expr;
        Children = new List<IASTNode> { expr };
    }

    public override IList<IASTNode> Children { get; }
  
    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()})";
    public ISymbolType SymbolType => throw new NotImplementedException() ;
}