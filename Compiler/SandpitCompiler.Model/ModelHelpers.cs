using SandpitCompiler.AST;

namespace SandpitCompiler.Model;

public static class ModelHelpers {
    private static readonly IDictionary<string, string> TypeLookupDict = new Dictionary<string, string> {
        { Constants.Bacon_Integer, "int" },
        { Constants.Bacon_String, "string" }
    };

    public static string TypeLookup(string t) => TypeLookupDict.ContainsKey(t) ? TypeLookupDict[t] : t;

    public static string AsLineSeparatedString(this IEnumerable<IModel> mm, int indent = 0) {
        var indentation = new string(' ', indent);
        return string.Join("\r\n", mm.Select(v => $"{indentation}{v}")).Trim();
    }

    public static string AsCommaSeparatedString(this IEnumerable<IModel> mm) => string.Join(", ", mm.Select(v => v.ToString())).Trim();
}