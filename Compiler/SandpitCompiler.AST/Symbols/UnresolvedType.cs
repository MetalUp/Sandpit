namespace SandpitCompiler.AST.Symbols;

public class UnresolvedType : ISymbolType {
    public UnresolvedType(string name) => Name = name;

    public string Name { get; }

    public ISymbolType Resolve(IScope scope) => scope.Resolve(Name)?.SymbolType ?? throw new ArgumentNullException();
}