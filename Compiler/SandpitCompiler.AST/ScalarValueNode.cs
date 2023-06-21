using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public class ScalarValueNode : ValueNode {
    public ScalarValueNode(IToken nodeSymbol) : base(nodeSymbol) { }

    public override string ToStringTree() => ToString();
}