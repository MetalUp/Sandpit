using System.Text;
using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public class ASTNode {
    public ASTNode() { }

    public ASTNode(IToken token) => Token = token;

    public ASTNode(string imaginary) => Token = new CommonToken(0, imaginary);

    public IToken? Token { get; }

    public IList<ASTNode> Children { get; set; } = new List<ASTNode>();

    public bool IsNil => Token is null;

    public string? Text => Token?.Text;

    public void AddChild(ASTNode t) => Children.Add(t);

    public int? GetNodeType() => Token?.Type;

    public override string ToString() {
        var typeName = GetType().Name;
        return Token != null ? $"<{typeName}, '{Token.Text}'>" : typeName;
    }

    public virtual string ToStringTree() {
        if (!Children.Any()) {
            return ToString();
        }

        var buf = new StringBuilder();

        if (!IsNil) {
            buf.Append('(');
            buf.Append(ToString());
            buf.Append(' ');
        }

        for (var i = 0; i < Children.Count; i++) {
            var t = Children[i];
            if (i > 0) {
                buf.Append(' ');
            }

            buf.Append(t.ToStringTree());
        }

        if (!IsNil) {
            buf.Append(')');
        }

        return buf.ToString();
    }
}