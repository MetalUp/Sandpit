namespace SandpitCompiler.SymbolTree; 

public class VariableSymbol : ISymbol {
    public string Name { get; }
    public IScope? Scope { get; set; }
    public ISymbolType? SymbolType { get; }

    public VariableSymbol(string name, ISymbolType? symbolType) {
        Name = name;
        SymbolType = symbolType;
    }

    public override string ToString() => SymbolType is not null ? $"<{Name}:{SymbolType}>" : Name;
}