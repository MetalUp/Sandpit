namespace SandpitCompiler.SymbolTree;

public interface IScope {
    public string ScopeName { get; }
    public IScope? EnclosingScope { get; }
    public void Define(ISymbol symbol);
    public ISymbol? Resolve(string name);
}