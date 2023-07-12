namespace SandpitCompiler.AST.Symbols;

public interface IUnresolvedType : ISymbolType {
    public ISymbolType Resolve(IScope scope);
}