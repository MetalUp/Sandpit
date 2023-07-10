using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class IndexedValueNode : ASTNode, IExpression {
    public IndexedValueNode(IExpression expr, IExpression index) {
        Expr = expr;
        Index = index;

        Children = new List<IASTNode> { expr, index };
    }

    public IExpression Expr { get; }
    public IExpression Index { get; }

    public override IList<IASTNode> Children { get; }
  
    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()}{Index.ToStringTree()})";
    public ISymbolType SymbolType => throw new NotImplementedException() ;
}