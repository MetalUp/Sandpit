using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class ConstDefinitionNode : ASTNode, IDefinition {
    public ConstDefinitionNode(ValueNode id, IExpression expression) {
        ID = id;
        Expression = expression;
        Children = new List<IASTNode> { ID, Expression };
    }

    public ValueNode ID { get; }
    public IExpression Expression { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType => Expression.SymbolType;
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expression.ToStringTree()})".TrimEnd();
}