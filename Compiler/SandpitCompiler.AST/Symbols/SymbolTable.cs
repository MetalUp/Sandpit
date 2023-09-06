

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Sandpit.Compiler.Lib;

namespace SandpitCompiler.AST.Symbols;

public class SymbolTable {
    private static ISymbolType? ConvertToBuiltInSymbol(Type type) =>
        type.Name switch {
            "Void" => null,
            "String" => Constants.ElanString,
            "Boolean" => Constants.ElanBool,
            "Int32" => Constants.ElanInt,
            "IEnumerable`1" => new IterableType(ConvertToBuiltInSymbol(type.GenericTypeArguments.First()) ?? throw new ArgumentException()),
            "IList`1" => new ListType(ConvertToBuiltInSymbol(type.GenericTypeArguments.First()) ?? throw new ArgumentException()),
            _ when type.Name.StartsWith("Func") => new FuncType(type.GenericTypeArguments.Select(ConvertToBuiltInSymbol).OfType<ISymbolType>().ToArray()),
            _ when type.IsGenericParameter => new GenericParameterType(type.Name), // placeholder for generic types 
            _ => throw new NotImplementedException(type.Name)
        };

    private ISymbol ConvertToMethodSymbol(MethodInfo method, MethodType methodType) {
        var name = method.Name;
        var type = ConvertToBuiltInSymbol(method.ReturnType);

        var ms = method.IsGenericMethod ? new GenericMethodSymbol(name, methodType, type, GlobalScope) : new MethodSymbol(name, methodType, type, GlobalScope);

        var pps = method.GetParameters().Select(p => (p.Name, ConvertToBuiltInSymbol(p.ParameterType)));

        foreach (var (n, st) in pps) {
            ms.Define(new VariableSymbol(n ?? throw new ArgumentException("name must not be null"), st));
        }

        return ms;
    }


    public SymbolTable() {

        var ar = new LibAssemblyReference();

        var lib = Assembly.GetAssembly(ar.GetType());

        var sc = lib?.ExportedTypes.ToArray() ?? throw new ArgumentException("no lib");

        var stdLib = sc.Single(t => t.Name == "StandardLib").GetMethods().Where(m => m.DeclaringType != typeof(object)).ToArray();
        var systemCalls = sc.Single(t => t.Name == "SystemCalls").GetMethods().Where(m => m.DeclaringType != typeof(object)).ToArray();

        InitTypeSystem(stdLib, systemCalls);
    }

    public GlobalScope GlobalScope { get; } = new();

    protected void InitTypeSystem(MethodInfo[] stdLib, MethodInfo[] systemCalls) {
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanBoolName));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanFloat));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanInt));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanNumber));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanStringName));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanCharName));
        //GlobalScope.Define(new BuiltInTypeSymbol(Constants.ElanDecimal));

        foreach (var slf in stdLib.Select(sc => ConvertToMethodSymbol(sc, MethodType.Function))) {
            GlobalScope.Define(slf);
        }

        foreach (var sc in systemCalls.Select(sc => ConvertToMethodSymbol(sc, MethodType.SystemCall))) {
            GlobalScope.Define(sc);
        }
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