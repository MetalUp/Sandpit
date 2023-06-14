namespace SandpitCompiler.AST;

public class FileNode : ASTNode {
    public FileNode(IEnumerable<ASTNode> constNodes, IEnumerable<ASTNode> procNodes, ASTNode? mainNode) {
        MainNode = mainNode is MainNode mn
            ? mn
            : mainNode is null
                ? null
                : throw new ArgumentException($"mainNode is {mainNode.GetType()} expect {typeof(MainNode)}");

        ConstNodes = constNodes.CheckType<ConstDeclNode>();
        ProcNodes = procNodes.CheckType<ProcNode>();
    }

    public ProcNode[] ProcNodes { get; }

    public ConstDeclNode[] ConstNodes { get; }

    public MainNode? MainNode { get; }

    public override string ToStringTree() => $"{ConstNodes.AsString()}{ProcNodes.AsString()}{MainNode?.ToStringTree() ?? ""}";
}