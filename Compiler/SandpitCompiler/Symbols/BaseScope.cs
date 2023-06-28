namespace SandpitCompiler.SymbolTree;

public abstract class BaseScope : IScope {
    private readonly Dictionary<string, ISymbol> symbols = new();

    protected BaseScope() {
        InitTypeSystem();
    }

    public abstract string ScopeName { get; }
    public abstract IScope? EnclosingScope { get; }

    public virtual void Define(ISymbol symbol) {
        symbols[symbol.Name] = symbol;
        symbol.Scope = this;
    }

    public virtual ISymbol? Resolve(string name) => symbols.ContainsKey(name) ? symbols[name] : EnclosingScope?.Resolve(name);

    protected void InitTypeSystem() {
        Define(new BuiltInTypeSymbol("Integer"));
        Define(new BuiltInTypeSymbol("String"));
        Define(new BuiltInTypeSymbol("Boolean"));
    }

    public override string ToString() => string.Join(',', symbols.Keys);
}