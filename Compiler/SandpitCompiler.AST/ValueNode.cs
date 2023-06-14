using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public class ValueNode : ASTNode {
    public ValueNode(IToken nodeSymbol) : base(nodeSymbol) { }

    public override string ToStringTree() => ToString();
}