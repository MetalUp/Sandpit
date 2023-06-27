namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ValueNode id, ParamNode[] parameters, BodyNode body) {
        ID = id;
        Parameters = parameters;
        Body = body;
     
    }

    public ValueNode ID { get; }
    public ParamNode[] Parameters { get; }
    public BodyNode Body { get; }
   

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {Parameters.AsString()} {Body.ToString()})";
}