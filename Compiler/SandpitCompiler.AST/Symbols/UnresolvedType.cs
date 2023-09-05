namespace SandpitCompiler.AST.Symbols;

public class UnresolvedType : IUnresolvedType {
    public UnresolvedType(string name) => Name = name;

    private string Name { get; }

    public virtual ISymbolType Resolve(IScope scope) => scope.Resolve(Name)?.SymbolType ?? throw new ArgumentNullException();
}