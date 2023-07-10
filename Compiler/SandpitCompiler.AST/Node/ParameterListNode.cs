using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ParameterListNode : ASTNode {
    public ParameterListNode(ValueNode id, params VarDefinitionNode[] varNodes) {
        ID = id;
        VarNodes = varNodes;
        Children = new List<IASTNode> { id }.Union(varNodes).ToList();
    }

    public ValueNode ID { get; }
    public VarDefinitionNode[] VarNodes { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {VarNodes.AsString()})";
}