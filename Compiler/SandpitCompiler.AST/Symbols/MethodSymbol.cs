namespace SandpitCompiler.AST.Symbols;

public class MethodSymbol : BaseScope, ISymbol {
    public MethodSymbol(string name, MethodType methodType, ISymbolType? symbolType, IScope scope) {
        Name = name;
        MethodType = methodType;
        SymbolType = symbolType;
        EnclosingScope = scope;
    }

    public override string ScopeName { get; } = "local";
    public override IScope? EnclosingScope { get; }
    public MethodType MethodType { get; }

    public ISymbolType? SymbolType { get; }
    public string Name { get; }
    public IScope? Scope { get; set; }

    public override string ToString() => $"{MethodType} {Name} {base.ToString()}";
}