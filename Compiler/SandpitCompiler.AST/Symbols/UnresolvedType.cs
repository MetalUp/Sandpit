using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Symbols;

public class UnresolvedType : ISymbolType {
    public UnresolvedType(string name) => Name = name;

    public string Name { get; }
}