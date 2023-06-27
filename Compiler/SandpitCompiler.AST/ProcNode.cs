namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ValueNode id, ParamNode[] parameters, BodyNode body) {
        ID = id;
        Parameters = parameters;
        Body = body;
        Children = new List<ASTNode> { id, body }.Union(parameters).ToList();
    }

    public ValueNode ID { get; }
    public ParamNode[] Parameters { get; }
    public BodyNode Body { get; }

    public override IList<ASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Body})";
}