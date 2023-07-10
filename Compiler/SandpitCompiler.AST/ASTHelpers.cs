﻿using Antlr4.Runtime;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST;

public static class ASTHelpers {
    public static string AsString(this IEnumerable<ASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();

    //public static string TokenToType(string t) =>
    //    t switch {
    //        "LITERAL_INTEGER" => "Int",
    //        "LITERAL_STRING" => "String",
    //        _ => throw new NotSupportedException()
    //    };


    public static ISymbolType TokenToType(IToken token) =>
        ASTHelpers.GetTokenName(token.Type) switch {
            "LITERAL_INTEGER" => new BuiltInType("Int"),
            "LITERAL_STRING" => new BuiltInType("String"),
            "IDENTIFIER" => new UnresolvedType(token.Text),
            "VALUE_TYPE" => new BuiltInType(token.Text),
            "BOOL_VALUE" => new BuiltInType("Bool"),
            "LITERAL_CHAR" => new BuiltInType("Char"),
            _ => throw new NotSupportedException()
        };

    public static Constants.Operators MapSymbolToOperator(string? symbol) {
        return symbol switch {
            "OP_EQ" => Constants.Operators.Eq,
            "OP_NE" => Constants.Operators.Ne,
            "PLUS" => Constants.Operators.Add,
            _ => Constants.Operators.Unknown
        };
    }

    public static Constants.Types MapSymbolToBuiltInType(string? symbol) {
        return symbol switch {
            "VALUE_TYPE" => Constants.Types.Value,
            "ARRAY" => Constants.Types.Array,
            "LIST" => Constants.Types.List,
            "DICTIONARY" => Constants.Types.Dictionary,
            "ITERABLE" => Constants.Types.Iterable,
            _ => Constants.Types.Unknown
        };
    }

    public static string GetTokenName(int tokenType) => SandpitParser.DefaultVocabulary.GetSymbolicName(tokenType) ?? "";
}