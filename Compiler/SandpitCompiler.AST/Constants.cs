namespace SandpitCompiler.AST;

public static class Constants {
    public enum Operators {
        Eq,
        Ne,
        Add,
        Minus,
        Multiply,
        Divide,
        Unknown
    }

    public enum Types {
        Value,
        Array,
        List,
        Dictionary,
        Iterable,
        Unknown
    }

    public static string LITERAL_INTEGER_TOKEN = "LITERAL_INTEGER";
    public static string LITERAL_STRING_TOKEN = "LITERAL_STRING";

    public const string Bacon_Integer = "Int";
    public const string Bacon_String = "String";

    public const string Bacon_Iterable = "Iterable";
    public const string Bacon_List = "List";
}