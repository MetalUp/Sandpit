using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class DereferenceNode : ASTNode, IExpression {
    public DereferenceNode(IExpression expr, ValueNode id)  {
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