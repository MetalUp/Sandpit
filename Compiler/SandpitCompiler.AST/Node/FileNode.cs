using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class FileNode : ASTNode {
    public FileNode(IEnumerable<ConstDefnNode> constNodes, IEnumerable<ProcDefnNode> procNodes, IEnumerable<FuncDefnNode> funcNodes, IEnumerable<MainNode> mainNodes) {
        ConstNodes = constNodes.ToArray();
        ProcNodes = procNodes.ToArray();
        FuncNodes = funcNodes.ToArray();
        MainNode = mainNodes.ToArray();
        Children = ConstNodes.Union<IASTNode>(ProcNodes).Union(FuncNodes).Union(MainNode).ToList();
    }

    public ProcDefnNode[] ProcNodes { get; }

    public ConstDefnNode[] ConstNodes { get; }

    public FuncDefnNode[] FuncNodes { get; }

    public MainNode[] MainNode { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"{ConstNodes.AsString()}{ProcNodes.AsString()}{MainNode.AsString()}";
}