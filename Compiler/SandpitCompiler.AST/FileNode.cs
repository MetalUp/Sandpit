using System.Text;

namespace SandpitCompiler.AST;

public class FileNode : ASTNode {
    public FileNode(IEnumerable<ASTNode> constNodes, ASTNode? mainNode) {
        MainNode = mainNode is MainNode mn
            ? mn
            : mainNode is null
                ? null
                : throw new ArgumentException($"mainNode is {mainNode.GetType()} expect {typeof(MainNode)}");

        ConstNodes = constNodes.OfType<ConstDeclNode>().ToArray();

        if (ConstNodes.Length != constNodes.Count()) {
            throw new ArgumentException("todo");
        }
    }

    public MainNode? MainNode { get; }

    public ConstDeclNode[] ConstNodes { get; }

    public override string ToStringTree() {
        var buf = new StringBuilder();

        for (var i = 0; i < ConstNodes.Length; i++) {
            var t = ConstNodes[i];
            if (i > 0) {
                buf.Append(' ');
            }

            buf.Append(t.ToStringTree());
        }

        buf.Append(MainNode?.ToStringTree() ?? "");

        return buf.ToString();
    }
}