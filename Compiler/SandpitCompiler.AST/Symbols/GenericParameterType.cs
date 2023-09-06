namespace SandpitCompiler.AST.Symbols;

public class GenericParameterType : ISymbolType {
    public GenericParameterType(string name) => Name = name;

    public string Name { get; }
    public ISymbolType Clone() => this;
}