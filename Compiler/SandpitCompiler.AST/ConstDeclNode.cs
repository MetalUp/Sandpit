using System.Text;

namespace SandpitCompiler.AST;

public class ConstDeclNode : ASTNode {
    public ConstDeclNode(ASTNode id, ASTNode @int) {
        ID = (ValueNode)id;
        Int = (ValueNode)@int;
    }

    public ValueNode ID { get; }
    public ValueNode Int { get; }

    public override string ToStringTree() {
        var buf = new StringBuilder();

        buf.Append('(');
        buf.Append(ToString());
        buf.Append(' ');

        buf.Append(ID.ToStringTree());

        buf.Append(Int.ToStringTree());

        buf.Append(")");

        return buf.ToString();
    }
}