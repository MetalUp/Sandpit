namespace SandpitCompiler.Model;

public static class ModelHelpers {
    public static readonly IDictionary<string, string> TypeLookup = new Dictionary<string, string> { { "Integer", "int" }, {"String", "string"} };

    public static string AsLineSeparatedString(this IEnumerable<IModel> mm, int indent = 0) {
        var indentation = new string(' ', indent);
        return string.Join("\r\n", mm.Select(v => $"{indentation}{v}")).Trim();
    }

    public static string AsCommaSeparatedString(this IEnumerable<IModel> mm) => string.Join(", ", mm.Select(v => v.ToString())).Trim();
}