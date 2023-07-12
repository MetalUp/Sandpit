namespace SandpitCompiler.AST.Symbols;

public class UnresolvedType : ISymbolType {
    public UnresolvedType(string name) => Name = name;

    public string Name { get; }

    public virtual ISymbolType Resolve(IScope scope) => scope.Resolve(Name)?.SymbolType ?? throw new ArgumentNullException();
}