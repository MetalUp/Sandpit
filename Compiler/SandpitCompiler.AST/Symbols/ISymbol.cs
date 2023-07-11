namespace SandpitCompiler.AST.Symbols;

public interface ISymbol {
    public ISymbolType? SymbolType { get; }

    public string Name { get; }

    public IScope? Scope { get; set; }
}