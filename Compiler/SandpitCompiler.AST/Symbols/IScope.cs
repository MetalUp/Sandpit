namespace SandpitCompiler.AST.Symbols;

public interface IScope {
    public string ScopeName { get; }
    public IScope? EnclosingScope { get; }

    public IEnumerable<IScope> ChildScopes { get; }

    public IEnumerable<ISymbol> Symbols { get; }

    public void Define(ISymbol symbol);
    public ISymbol? Resolve(string name);
}