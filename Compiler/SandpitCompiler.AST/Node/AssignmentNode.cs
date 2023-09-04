using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class AssignmentNode : ASTNode, IStatement {
    public AssignmentNode(IValue id, IExpression expr) {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { id, expr };
        SymbolType = expr.SymbolType;
    }

    public IValue ID { get; }
    public IExpression Expr { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}