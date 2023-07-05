using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class DereferenceNode : ValueNode {
    public DereferenceNode(ValueNode expr, ValueNode id) : base(null) {
        Expr = expr;
        ID = id;
        Children = new List<IASTNode> { expr, id };
    }

    public ValueNode Expr { get; }
    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => ToString();
}