using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class FileNode : ASTNode {
    public FileNode(IEnumerable<ConstDefinitionNode> constNodes, IEnumerable<ProcedureDefinitionNode> procNodes, IEnumerable<FunctionDefinitionNode> funcNodes, IEnumerable<MainNode> mainNodes) {
        ConstNodes = constNodes.ToArray();
        ProcNodes = procNodes.ToArray();
        FuncNodes = funcNodes.ToArray();
        MainNode = mainNodes.ToArray();
        Children = ConstNodes.Union<IASTNode>(ProcNodes).Union(FuncNodes).Union(MainNode).ToList();
    }

    public ProcedureDefinitionNode[] ProcNodes { get; }

    public ConstDefinitionNode[] ConstNodes { get; }

    public FunctionDefinitionNode[] FuncNodes { get; }

    public MainNode[] MainNode { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"{ConstNodes.AsString()}{ProcNodes.AsString()}{MainNode.AsString()}";
}