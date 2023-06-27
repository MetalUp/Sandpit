namespace SandpitCompiler.AST;

public class ProcStatNode : StatNode {
    public ProcStatNode(ValueNode id, ValueNode[] parameters) {
        ID = id;
        Parameters = parameters;
    }

    public ValueNode ID { get; }
    public ValueNode[] Parameters { get; }

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}  {Parameters.AsString()} )";
}