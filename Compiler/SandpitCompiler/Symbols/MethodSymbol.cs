namespace SandpitCompiler.SymbolTree;

public class MethodSymbol : BaseScope, ISymbol {
    public MethodSymbol(string name, ISymbolType symbolType, IScope scope) {
        Name = name;
        EnclosingScope = scope;
    }

    public ISymbolType? SymbolType => null;
    public string Name { get; }
    public override string ScopeName { get; } = "local";
    public override IScope? EnclosingScope { get; }
}