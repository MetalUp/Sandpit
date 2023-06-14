namespace SandpitCompiler.AST;

public class MainNode : ASTNode {
    public MainNode(IEnumerable<ASTNode> varNodes) {
        VarNodes = varNodes.OfType<VarDeclNode>().ToArray();

        if (VarNodes.Length != varNodes.Count()) {
            throw new ArgumentException("todo");
        }
    }

    public VarDeclNode[] VarNodes { get; }

    public override string ToStringTree() {
        var varNodesAsString = VarNodes.Aggregate("", (acc, vn) => $"{acc}{vn.ToStringTree()} ").TrimEnd();

        return $"({ToString()} {varNodesAsString})";
    }
}