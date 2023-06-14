namespace SandpitCompiler.AST;

public static class ASTHelpers {
    public static T[] CheckType<T>(this IEnumerable<ASTNode> nodes) {
        var ofTypeNodes = nodes.OfType<T>().ToArray();
        if (ofTypeNodes.Length != nodes.Count()) {
            throw new ArgumentException("expect all nodes to be of type {T}");
        }

        return ofTypeNodes;
    }

    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();
}