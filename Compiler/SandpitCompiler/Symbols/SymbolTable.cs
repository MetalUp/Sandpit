namespace SandpitCompiler.SymbolTree;

public class SymbolTable  {
    public GlobalScope GlobalScope { get; } = new GlobalScope();

    public SymbolTable() {
        InitTypeSystem();
    }

    protected void InitTypeSystem() {
        GlobalScope.Define(new BuiltInTypeSymbol("Integer"));
        GlobalScope.Define(new BuiltInTypeSymbol("String"));
        GlobalScope.Define(new BuiltInTypeSymbol("Boolean"));
    }
}