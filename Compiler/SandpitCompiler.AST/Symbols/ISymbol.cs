using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.SymbolTree;

public interface ISymbol {
    public ISymbolType? SymbolType { get; }

    public string Name { get; }

    public IScope? Scope { get; set; }
}