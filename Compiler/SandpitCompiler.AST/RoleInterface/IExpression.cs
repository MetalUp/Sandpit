using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.RoleInterface; 

public interface IExpression : IASTNode {
    ISymbolType SymbolType { get; }
}