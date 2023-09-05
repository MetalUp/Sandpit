namespace SandpitCompiler.AST.Symbols;

public class FuncType : ISymbolType {
    public ISymbolType[] ElementTypes { get; } = Array.Empty<ISymbolType>();
}