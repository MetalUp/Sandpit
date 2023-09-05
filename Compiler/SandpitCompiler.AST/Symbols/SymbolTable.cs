

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Sandpit.Compiler.Lib;

namespace SandpitCompiler.AST.Symbols;


//VALUE_TYPE:  'Value' | 'Int' | 'Float' | 'Decimal' | 'Number' | 'Char' | 'String' | 'Bool' ;
//ARRAY: 'Array';
//LIST:  'List';
//DICTIONARY: 'Dictionary';
//ITERABLE: 'Iter';
//RANDOM: 'Random';  //For pure functional random number generation only



public class SymbolTable {
    private static ISymbolType? ConvertToBuiltInSymbol(Type type) =>
        type.Name switch {
            "Void" => null, 
            "String" => new BuiltInType("String"), 
            "Boolean" => new BuiltInType("Bool"), 
            "Int32" => new BuiltInType("Int"), 
            "IEnumerable`1" => new IterableType(ConvertToBuiltInSymbol(type.GenericTypeArguments.First())),
            "IList`1" => new ListType(ConvertToBuiltInSymbol(type.GenericTypeArguments.First())),
            "Func`1" => new FuncType(),
            "Func`2" => new FuncType(),
            "Func`3" => new FuncType(),
            _  when type.IsGenericParameter  => new GenericParameterType(type.Name), // todo placeholder for generic types 
            _ => throw new NotImplementedException(type.Name)
        };

    private ISymbol ConvertToMethodSymbol(MethodInfo method, MethodType methodType) {
        var name = method.Name;
        var type = ConvertToBuiltInSymbol(method.ReturnType);

        var ms = method.IsGenericMethod ? new GenericMethodSymbol(name, methodType, type, GlobalScope) : new MethodSymbol(name, methodType, type, GlobalScope);

        var pps = method.GetParameters().Select(p => (p.Name, ConvertToBuiltInSymbol(p.ParameterType)));

        foreach (var (n, st) in pps) {
            ms.Define(new VariableSymbol(n, st));
        }

        return ms;
    }


    public SymbolTable() {

        var ar = new LibAssemblyReference();

        var lib = Assembly.GetAssembly(ar.GetType());

        var sc = lib.ExportedTypes;

        var stdLib = sc.Single(t => t.Name == "StandardLib").GetMethods().Where(m => m.DeclaringType != typeof(object)).ToArray();
        var systemCalls = sc.Single(t => t.Name == "SystemCalls").GetMethods().Where(m => m.DeclaringType != typeof(object)).ToArray();

        InitTypeSystem(stdLib, systemCalls);
    }

    public GlobalScope GlobalScope { get; } = new();

    protected void InitTypeSystem(MethodInfo[] stdLib, MethodInfo[] systemCalls) {
        GlobalScope.Define(new BuiltInTypeSymbol("Int"));
        GlobalScope.Define(new BuiltInTypeSymbol("Float"));
        GlobalScope.Define(new BuiltInTypeSymbol("Decimal"));
        GlobalScope.Define(new BuiltInTypeSymbol("Number"));
        GlobalScope.Define(new BuiltInTypeSymbol("Char"));
        GlobalScope.Define(new BuiltInTypeSymbol("String"));
        GlobalScope.Define(new BuiltInTypeSymbol("Bool"));

        //GlobalScope.Define(new MethodSymbol("max", MethodType.Function, new BuiltInType("Int"), GlobalScope));

        //GlobalScope.Define(new MethodSymbol("contains", MethodType.Function, new BuiltInType("Boolean"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("indexOf", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("range", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("filter", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("groupBy", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("count", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("map", MethodType.Function, new BuiltInType("Int"), GlobalScope));
        //GlobalScope.Define(new MethodSymbol("asList", MethodType.Function, new BuiltInType("Int"), GlobalScope));

        //// TODO Kludge
        //GlobalScope.Define(new MethodSymbol("reduce", MethodType.Function, new TupleType(new ISymbolType[] { new BuiltInType("String"), new BuiltInType("Int") }), GlobalScope));

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