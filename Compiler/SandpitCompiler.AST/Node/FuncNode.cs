using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class FuncNode : ASTNode, IProc {
    public FuncNode(ValueNode id, ValueNode type, ParamNode[] paramNodes, FuncBodyNode body) {
        ID = id;
        Type = type;
        ParamNodes = paramNodes;
        Body = body;
        Children = new List<IASTNode> { id, type, body }.Union(ParamNodes).ToList();
    }

    public ValueNode Type { get; }
    public ParamNode[] ParamNodes { get; }
    public FuncBodyNode Body { get; }

    public ValueNode ID { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()} {ParamNodes.AsString()} {Type.ToStringTree()} {Body.ToStringTree()})";
}