using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class LetDefnNode : StatNode, IDecl {
    public LetDefnNode(ValueNode id, ValueNode expr) {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { ID, Expr };
        SymbolType = ASTHelpers.TokenToType(expr.Token ?? throw new ArgumentNullException());
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public string Id => ID.Text;
    public ISymbolType SymbolType { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}