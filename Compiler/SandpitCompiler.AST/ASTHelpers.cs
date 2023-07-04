﻿using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST;

public static class ASTHelpers {
    private static readonly IDictionary<string, string> TokenToTypeDict = new Dictionary<string, string> {
        { Constants.LITERAL_INTEGER_TOKEN, Constants.Bacon_Integer },
        { Constants.LITERAL_STRING_TOKEN, Constants.Bacon_String }
    };

    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();

    public static string TokenToType(string t) => TokenToTypeDict.ContainsKey(t) ? TokenToTypeDict[t] : t;

    public static Constants.Operators MapSymbolToOperator(string? symbol) {
        return symbol switch {
            "OP_EQ" => Constants.Operators.Eq,
            "OP_NE" => Constants.Operators.Ne,
            _ => Constants.Operators.Unknown
        };
    }

    public static string GetTokenName(int tokenType) => SandpitParser.DefaultVocabulary.GetSymbolicName(tokenType) ?? "";
}