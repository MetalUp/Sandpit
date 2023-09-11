using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LetVariableDefinitionNode : ASTNode, IStatement, IDefinition {
    public LetVariableDefinitionNode(IValue id, IExpression expr) {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { id, expr };
    }

    public IValue ID { get; }
    public IExpression Expr { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType => Expr.SymbolType;

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}