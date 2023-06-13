using System.Text;

namespace SandpitCompiler.AST;

public class VarDeclNode : ASTNode {
    public VarDeclNode(ASTNode id, ASTNode expr) {
        ID = (ValueNode)id;
        Expr = (ValueNode)expr;
    }

    public ValueNode ID { get; }
    public ValueNode Expr { get; }

    public override string ToStringTree() {
        var buf = new StringBuilder();

        buf.Append('(');
        buf.Append(ToString());
        buf.Append(' ');

        buf.Append(ID.ToStringTree());

        buf.Append(Expr.ToStringTree());

        buf.Append(")");

        return buf.ToString();
    }
}