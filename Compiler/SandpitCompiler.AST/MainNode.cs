using System.Text;

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
        var buf = new StringBuilder();

        buf.Append('(');
        buf.Append(ToString());
        buf.Append(' ');

        for (var i = 0; i < VarNodes.Length; i++) {
            var t = VarNodes[i];
            if (i > 0) {
                buf.Append(' ');
            }

            buf.Append(t.ToStringTree());
        }

        buf.Append(')');

        return buf.ToString();
    }
}