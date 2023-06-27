namespace SandpitCompiler.SymbolTree;

public class BuiltInTypeSymbol : ISymbol {
    public ISymbolType? SymbolType => null;
    public string Name { get; }
    public BuiltInTypeSymbol(string name) {
        Name = name;
    }
}