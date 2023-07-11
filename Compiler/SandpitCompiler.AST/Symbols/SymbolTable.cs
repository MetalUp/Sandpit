namespace SandpitCompiler.AST.Symbols;

public class SymbolTable {
    public SymbolTable() {
        InitTypeSystem();
    }

    public GlobalScope GlobalScope { get; } = new();

    protected void InitTypeSystem() {
        GlobalScope.Define(new BuiltInTypeSymbol("Int"));
        GlobalScope.Define(new BuiltInTypeSymbol("String"));
        GlobalScope.Define(new BuiltInTypeSymbol("Boolean"));

        GlobalScope.Define(new MethodSymbol("max", new BuiltInType("Int"), GlobalScope));
    }

    private IList<IScope> ChildScopes(IEnumerable<IScope> scopes) {
        var allScopes = new List<IScope>();
        foreach (var scope in scopes) {
            allScopes.Add(scope);
            allScopes.AddRange(ChildScopes(scope.ChildScopes));
        }

        return allScopes;
    }

    public IEnumerable<IScope> Scopes() => ChildScopes(new[] { GlobalScope });
}