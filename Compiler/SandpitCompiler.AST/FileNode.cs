namespace SandpitCompiler.AST;

public class FileNode : ASTNode {
    public FileNode(IEnumerable<ConstDeclNode> constNodes, IEnumerable<ProcNode> procNodes, IEnumerable<FuncNode> funcNodes, IEnumerable<MainNode> mainNodes) {
        ConstNodes = constNodes.ToArray();
        ProcNodes = procNodes.ToArray();
        FuncNodes = funcNodes.ToArray();
        MainNode = mainNodes.ToArray();
    }

    public ProcNode[] ProcNodes { get; }

    public ConstDeclNode[] ConstNodes { get; }

    public FuncNode[] FuncNodes { get; }

    public MainNode[] MainNode { get; }

    public override string ToStringTree() => $"{ConstNodes.AsString()}{ProcNodes.AsString()}{MainNode.AsString()}";
}