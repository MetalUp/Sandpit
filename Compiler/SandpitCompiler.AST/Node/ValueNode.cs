using Antlr4.Runtime;

namespace SandpitCompiler.AST.Node;

public abstract class ValueNode : ASTNode {
    protected ValueNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public TypeNode InferredType => new BuiltInTypeNode(Token);

    public override string ToStringTree() => ToString();
}