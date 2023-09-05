using Antlr4.Runtime;

namespace SandpitCompiler.AST.Node;

public abstract class TypeNode : ValueNode {
    protected TypeNode(IToken? nodeSymbol) : base(nodeSymbol) { }
}