using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public static class ASTHelpers {
    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();


  



}