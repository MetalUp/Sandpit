using Antlr4.Runtime;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public abstract class ValueNode : ASTNode {
    protected ValueNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public TypeNode InferredType => new BuiltInTypeNode(Token);


    public abstract ISymbolType SymbolType { get;}

    public override string ToStringTree() => ToString();
}