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

    public static string Bacon_Integer = "Int";
    public static string Bacon_String = "String";
}