namespace SandpitCompiler.AST;

public class ProcNode : ASTNode {
    public ProcNode(ValueNode id, ParamNode[] paramNodes, BodyNode bodyNode) {
        ID = id;
        ParamNodes = paramNodes;
        BodyNode = bodyNode;
     
    }

    public ValueNode ID { get; }
    public ParamNode[] ParamNodes { get; }
    public BodyNode BodyNode { get; }
   

    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {ParamNodes.AsString()} {BodyNode.ToString()})";
}