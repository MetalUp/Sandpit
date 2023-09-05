namespace SandpitCompiler.AST;

public static class Constants {
    public enum Operators {
        Eq,
        Ne,
        Add,
        Minus,
        Multiply,
        Divide,
        Lt,
        Gt,
        Unknown,
        And,
        Or,
        Xor
    }

    public enum Types {
        Value,
        Array,
        List,
        Dictionary,
        Iterable,
        Unknown
    }

    public const string ElanInt = "Int";
    public const string ElanString = "String";
    public const string ElanBool = "Bool";

    public const string ElanIter = "Iter";
    public const string ElanList = "List";
    public const string ElanChar = "Char";

    public static string LITERAL_INTEGER_TOKEN = "LITERAL_INTEGER";
    public static string LITERAL_STRING_TOKEN = "LITERAL_STRING";
}