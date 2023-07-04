using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;

namespace SandpitCompiler.Model;

public static class ModelHelpers {


    public static string TypeLookup(string t)
    {
        return t switch
        {
            Constants.Bacon_Integer => "int",
            Constants.Bacon_String => "string",
            _ => "",
        };
    }

    private static string TypeLookup(GenericTypeNode tn) {
        return tn.Text switch {
            Constants.Bacon_Iterable => $"IEnumerable<{TypeLookup(tn.ParameterizedType)}>",
            Constants.Bacon_List => $"IList<{TypeLookup(tn.ParameterizedType)}>",
            _ => "",
        };
    }

    private static string TypeLookup(BuiltInTypeNode tn) {
        return tn.Text switch {
            Constants.Bacon_Integer => "int",
            Constants.Bacon_String => "string",
            _ => "",
        };
    }

    public static string TypeLookup(TypeNode tn) {
        return tn switch {
            BuiltInTypeNode n => TypeLookup(n),
            GenericTypeNode n => TypeLookup(n),
            _ => "",
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
            _ => throw new NotImplementedException()
        };
    }
}