namespace SandpitCompiler.SymbolTree;

public class BuiltInTypeSymbol : ISymbol {
    public BuiltInTypeSymbol(string name) => Name = name;

    public ISymbolType? SymbolType => null;
    public string Name { get; }
    public IScope? Scope { get; set; }

    public override string ToString() => SymbolType is not null ? $"<{Name}:{SymbolType}>" : Name;
}