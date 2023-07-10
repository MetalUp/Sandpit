using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public abstract class TypeNode : ASTNode {
    protected TypeNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public abstract ISymbolType SymbolType { get; } 

}