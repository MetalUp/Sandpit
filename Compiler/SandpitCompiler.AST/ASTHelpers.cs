using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST;

public static class ASTHelpers {
    public static string AsString(this IEnumerable<IASTNode> nodes) => nodes.Aggregate("", (acc, n) => $"{acc}{n.ToStringTree()} ").TrimEnd();

    private static ISymbolType TextToType(string text) =>
        text switch {
            Constants.ElanIntName => Constants.ElanInt,
            Constants.ElanStringName => Constants.ElanString,
            Constants.ElanBoolName => Constants.ElanBool,
            Constants.ElanCharName => Constants.ElanChar,
            Constants.ElanDecimalName => Constants.ElanDecimal,
            Constants.ElanFloatName => Constants.ElanFloat,
            Constants.ElanNumberName => Constants.ElanNumber,
            _ => throw new NotImplementedException(text)
        };

    public static ISymbolType TokenToType(IToken token) =>
        GetTokenName(token.Type) switch {
            "LITERAL_INTEGER" => Constants.ElanInt,
            "LITERAL_STRING" => Constants.ElanString,
            "BOOL_VALUE" => Constants.ElanBool,
            "LITERAL_CHAR" => Constants.ElanChar,
            "VALUE_TYPE" => TextToType(token.Text),
            "IDENTIFIER" => new UnresolvedType(token.Text),
            "OP_EQ" => new OperatorType(Constants.Operators.Eq),
            "OP_NE" => new OperatorType(Constants.Operators.Ne),
            "PLUS" => new OperatorType(Constants.Operators.Add),
            "LT" => new OperatorType(Constants.Operators.Lt),
            "OP_AND" => new OperatorType(Constants.Operators.And),
            "OP_OR" => new OperatorType(Constants.Operators.Or),
            "OP_XOR" => new OperatorType(Constants.Operators.Xor),
            _ => throw new NotSupportedException()
        };

    public static Constants.Operators MapSymbolToOperator(string? symbol) {
        return symbol switch {
            "OP_EQ" => Constants.Operators.Eq,
            "OP_NE" => Constants.Operators.Ne,
            "PLUS" => Constants.Operators.Add,
            "LT" => Constants.Operators.Lt,
            "OP_AND" => Constants.Operators.And,
            "OP_OR" => Constants.Operators.Or,
            "OP_XOR" => Constants.Operators.Xor,
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