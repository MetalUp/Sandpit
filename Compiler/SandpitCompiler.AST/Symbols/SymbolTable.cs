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

        GlobalScope.Define(new MethodSymbol("max", MethodType.Function, new BuiltInType("Int"), GlobalScope));

        GlobalScope.Define(new MethodSymbol("contains", MethodType.Function, new BuiltInType("Boolean"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("indexOf", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("range", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("filter", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("groupBy", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("count", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("map", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        GlobalScope.Define(new MethodSymbol("asList", MethodType.Function, new BuiltInType("Int"), GlobalScope));

        // TODO Kludge
        GlobalScope.Define(new MethodSymbol("reduce", MethodType.Function, new TupleType(new ISymbolType[] { new BuiltInType("String"), new BuiltInType("Int") }), GlobalScope));

        GlobalScope.Define(new MethodSymbol("print", MethodType.SystemCall, null, GlobalScope));
        GlobalScope.Define(new MethodSymbol("printLine", MethodType.SystemCall, null, GlobalScope));
        GlobalScope.Define(new MethodSymbol("input", MethodType.SystemCall, new BuiltInType("String"), GlobalScope));
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