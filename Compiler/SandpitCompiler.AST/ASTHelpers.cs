using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST;

public static class ASTHelpers {
    private static readonly IDictionary<string, string> TokenToTypeDict = new Dictionary<string, string> { { "INT", "Integer" }, { "STRING", "String" } };
    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();

    public static string TokenToType(string t) => TokenToTypeDict.ContainsKey(t) ? TokenToTypeDict[t] : t;
}