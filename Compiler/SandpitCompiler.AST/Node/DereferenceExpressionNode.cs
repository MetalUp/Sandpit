using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class DereferenceExpressionNode : ASTNode, IExpression {
    public DereferenceExpressionNode(IExpression expr, ValueNode id) {
        Expr = expr;
        ID = id;
        Children = new List<IASTNode> { expr, id };
    }

    public IExpression Expr { get; }
    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => ToString();
    public ISymbolType SymbolType => throw new NotImplementedException();
}