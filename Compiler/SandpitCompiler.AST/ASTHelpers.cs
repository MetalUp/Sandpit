namespace SandpitCompiler.AST;

public static class ASTHelpers {
    public static IDictionary<int, string> NodeToType = new Dictionary<int, string> { { 20, "Integer" }, { 21, "String" } };
    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();
}