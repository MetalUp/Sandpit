namespace SandpitCompiler.SymbolTree; 

public class VariableSymbol : ISymbol {
    public string Name { get; }
    public ISymbolType SymbolType { get; }

    public VariableSymbol(string name, ISymbolType symbolType) {
        Name = name;
        SymbolType = symbolType;
    }
}