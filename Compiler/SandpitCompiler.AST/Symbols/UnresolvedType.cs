namespace SandpitCompiler.AST.Symbols;

public class UnresolvedType : IUnresolvedType {
    public UnresolvedType(string name) => Name = name;

    private string Name { get; }

    public ISymbolType Resolve(IScope scope, int depth = 0) {
        if (depth >= IUnresolvedType.MaxDepth) {
            throw new ArgumentException("too deep");
        }

        var t = scope.Resolve(Name)?.SymbolType ?? throw new ArgumentNullException();
        return t is IUnresolvedType ut ? ut.Resolve(scope, ++depth) : t;
    }

    public ISymbolType Clone() => this;
}