namespace SandpitCompiler.AST.Symbols;

public class BuiltInType : ISymbolType {
    public BuiltInType(string name) => Name = name;

    public string Name { get; }

    public override string ToString() => Name;
    public ISymbolType Clone() => this;
}