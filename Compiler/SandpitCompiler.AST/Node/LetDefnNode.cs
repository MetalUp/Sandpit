using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LetDefnNode : ASTNode, IStatement, IExpression {
    public LetDefnNode(IValue id, IExpression expr, IExpression returnExpression) {
        ID = id;
        Expr = expr;
        ReturnExpression = returnExpression;
        Children = new List<IASTNode> { ID, Expr };
        SymbolType = expr.SymbolType;
    }

    public IValue ID { get; }
    public IExpression Expr { get; }
    public IExpression ReturnExpression { get; }

    public ISymbolType SymbolType { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}