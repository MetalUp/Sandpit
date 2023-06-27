namespace SandpitCompiler.AST;

public class ProcStatNode : StatNode {
    public ProcStatNode(ValueNode id, ValueNode[] parameters) {
        ID = id;
        Parameters = parameters;
        Children = new List<ASTNode> { id }.Union(parameters).ToList();
    }

    public ValueNode ID { get; }
    public ValueNode[] Parameters { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}