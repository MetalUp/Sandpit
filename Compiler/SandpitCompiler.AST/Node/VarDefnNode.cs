using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class VarDefnNode : StatNode, IDecl {
    public VarDefnNode(ValueNode id, IExpression expr) {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { id, expr };
        SymbolType = expr.SymbolType;
    }

    public ValueNode ID { get; }
    public IExpression Expr { get; }

    public override IList<IASTNode> Children { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}