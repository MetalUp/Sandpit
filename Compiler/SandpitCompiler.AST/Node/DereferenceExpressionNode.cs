using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class DereferenceExpressionNode : ASTNode, IExpression {
    public DereferenceExpressionNode(IExpression expression, ValueNode id) {
        Expression = expression;
        ID = id;
        Children = new List<IASTNode> { expression, id };
    }

    public IExpression Expression { get; }
    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()}{Expression.ToStringTree()}{ID.ToStringTree()})".TrimEnd();
    public ISymbolType SymbolType => throw new NotImplementedException();
}