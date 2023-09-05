namespace SandpitCompiler.AST.Symbols;

public class VariableSymbol : ISymbol {
    public VariableSymbol(string name, ISymbolType? symbolType) {
        Name = name;
        SymbolType = symbolType;
    }

    public string Name { get; }
    public IScope? Scope { get; set; }
    public ISymbolType? SymbolType { get; }

    public override string ToString() => SymbolType is not null ? $"<{Name}:{SymbolType}>" : Name;
}