using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Symbols;

public class BuiltInType : ISymbolType {
    public BuiltInType(string name) => Name = name;

    public string Name { get; }
}