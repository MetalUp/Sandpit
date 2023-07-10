using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.SymbolTree;

public class MethodSymbol : BaseScope, ISymbol {
    public MethodSymbol(string name, ISymbolType? symbolType, IScope scope) {
        Name = name;
        SymbolType = symbolType;
        EnclosingScope = scope;
    }

    public override string ScopeName { get; } = "local";
    public override IScope? EnclosingScope { get; }

    public ISymbolType? SymbolType { get; }
    public string Name { get; }
    public IScope? Scope { get; set; }

    public override string ToString() => $"method {base.ToString()}";
}