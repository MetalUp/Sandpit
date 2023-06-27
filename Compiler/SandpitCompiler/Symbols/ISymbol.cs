namespace SandpitCompiler.SymbolTree;

public interface ISymbol {
    public ISymbolType? SymbolType { get; }

    public string Name { get; }
}