using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.RoleInterface;

public interface IDecl : IASTNode {
    public string Id { get; }

    public ISymbolType SymbolType { get; }
}