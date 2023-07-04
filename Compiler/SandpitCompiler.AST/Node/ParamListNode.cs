using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ParamListNode : ASTNode {
    public ParamListNode(ValueNode id, params VarDefnNode[] varNodes) {
        ID = id;
        VarNodes = varNodes;
        Children = new List<IASTNode> { id }.Union(varNodes).ToList();
    }

    public ValueNode ID { get; }
    public VarDefnNode[] VarNodes { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}