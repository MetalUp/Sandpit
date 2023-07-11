namespace SandpitCompiler.AST.Symbols;

public class BuiltInType : ISymbolType {
    public BuiltInType(string name) => Name = name;

    public string Name { get; }
}