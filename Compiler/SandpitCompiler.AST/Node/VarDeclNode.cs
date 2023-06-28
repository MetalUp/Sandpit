using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class VarDeclNode : StatNode, IDecl {
    public VarDeclNode(ValueNode id, ValueNode expr) {
        ID = id;
        Expr = expr;
        Children = new List<IASTNode> { id, expr };
        InferredType = ASTHelpers.TokenToType(expr.TokenName);
    }

    public string InferredType { get; set; }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override IList<IASTNode> Children { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType => Expr is ListNode ? new ListType(new BuiltInType(InferredType)) : new BuiltInType(InferredType);
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Expr.ToStringTree()})";
}