using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Model;

public static class ModelHelpers {
    public static string TypeLookup(string t) {
        return t switch {
            Constants.Bacon_Integer => "int",
            Constants.Bacon_String => "string",
            Constants.Bacon_Bool => "bool",
            Constants.Bacon_Char => "char",
            _ => throw new NotImplementedException()
        };
    }

    private static string TypeLookup(GenericTypeNode tn) {
        return tn.TokenName switch {
            "ITERABLE" => $"IEnumerable<{TypeLookup(tn.ParameterizedType)}>",
            "LIST" => $"IList<{TypeLookup(tn.ParameterizedType)}>",
            _ => throw new NotImplementedException()
        };
    }

    private static string TypeLookup(TupleTypeNode tn) {
        var types = tn.Items.Select(TypeLookup);
        return $"({string.Join(", ", types)})";
    }

    private static string TypeLookup(BuiltInTypeNode tn) {
        return tn.TokenName switch {
            "LITERAL_INTEGER" => "int",
            "LITERAL_STRING" => "string",
            "LITERAL_CHAR" => "char",
            "BOOL_VALUE" => "bool",
            "VALUE_TYPE" => TypeLookup(tn.Text),
            "IDENTIFIER" => "", // TODO Symbol table lookup ? 
            "OP_EQ" => "", // TODO Symbol table lookup ? 
            "OP_NE" => "", // TODO Symbol table lookup ? 
            "PLUS" => "", // TODO Symbol table lookup ? 
            _ => throw new NotImplementedException()
        };
    }

    public static string TypeLookup(TypeNode tn) {
        return tn switch {
            BuiltInTypeNode n => TypeLookup(n),
            GenericTypeNode n => TypeLookup(n),
            TupleTypeNode n => TypeLookup(n),
            _ => throw new NotImplementedException()
        };
    }

    public static string TypeLookup(ISymbolType? st, IScope scope) {
        return st switch {
            BuiltInType n => TypeLookup(n.Name),
            ListType n => $"IList<{TypeLookup(n.ElementType, scope)}>",
            TupleType n => $"({string.Join(", ", n.ElementTypes.Select(st1 => TypeLookup(st1,scope)).ToArray())})",
            UnresolvedType u =>  TypeLookup(u.Resolve(scope), scope), 
            _ => throw new NotImplementedException()
        };
    }

    public static bool IsTuple(ISymbolType? st, IScope scope) {
        return st switch {
            TupleType n => true,
            UnresolvedType u => IsTuple(u.Resolve(scope), scope),
            _ => false
        };
    }

    public static string ImplTypeLookup(ISymbolType? st, IScope scope) {
        return st switch {
            BuiltInType n => TypeLookup(n.Name),
            ListType n => $"List<{TypeLookup(n.ElementType, scope)}>",
            TupleType n => $"({string.Join(", ", n.ElementTypes.Select(st1 => TypeLookup(st1, scope)).ToArray())})",
            _ => throw new NotImplementedException()
        };
    }

    public static string PrefixLookup(ISymbolType? st) {
        return st switch {
            BuiltInType n => "const",
            ListType n => "static readonly",
            TupleType n => "static readonly",
            _ => throw new NotImplementedException()
        };
    }

    public static string AsLineSeparatedString(this IEnumerable<IModel> mm, int indent = 0) {
        var indentation = new string(' ', indent);
        return string.Join("\r\n", mm.Select(v => $"{indentation}{v}")).Trim();
    }

    public static string AsCommaSeparatedString(this IEnumerable<IModel> mm) => string.Join(", ", mm.Select(v => v.ToString())).Trim();

    public static string OperatorLookup(Constants.Operators op) {
        return op switch {
            Constants.Operators.Eq => "==",
            Constants.Operators.Ne => "!=",
            Constants.Operators.Add => "+",
            _ => throw new NotImplementedException()
        };
    }
}