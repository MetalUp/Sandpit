namespace SandpitCompiler.AST.Symbols;

public interface IHasElementsSymbolType : ISymbolType {
    public ISymbolType[] ElementTypes { get; }
}