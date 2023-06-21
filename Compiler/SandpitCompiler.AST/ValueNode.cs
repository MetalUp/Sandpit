using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public abstract class ValueNode : ASTNode {
    protected ValueNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public string InferredType => ASTHelpers.TokenToType[TokenName];

    public override string ToStringTree() => ToString();
}