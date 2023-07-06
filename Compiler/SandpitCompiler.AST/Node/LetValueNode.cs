using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class LetValueNode : ValueNode {
    public LetValueNode(ValueNode id, ValueNode expr) : base(null) {
        ID = id;
        Expr = expr;

        Children = new List<IASTNode> { id , expr }.ToList();
    }


    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Expr.ToStringTree()} )";
}