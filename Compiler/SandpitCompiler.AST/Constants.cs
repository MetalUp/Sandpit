using SandpitCompiler.AST.Symbols;

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

    public const string ElanIntName = "Int";
    public const string ElanStringName = "String";
    public const string ElanBoolName = "Bool";
    public const string ElanFloatName = "Float";
    public const string ElanDecimalName = "Decimal";
    public const string ElanCharName = "Char";
    public const string ElanNumberName = "Number";

    public static readonly BuiltInType ElanInt = new(ElanIntName);
    public static readonly BuiltInType ElanString = new(ElanStringName);
    public static readonly BuiltInType ElanBool = new(ElanBoolName);
    public static readonly BuiltInType ElanFloat = new(ElanFloatName);
    public static readonly BuiltInType ElanDecimal = new(ElanDecimalName);
    public static readonly BuiltInType ElanChar = new(ElanCharName);
    public static readonly BuiltInType ElanNumber = new(ElanNumberName);


    public const string ElanIter = "Iter";
    public const string ElanList = "List";
   

    public static string LITERAL_INTEGER_TOKEN = "LITERAL_INTEGER";
    public static string LITERAL_STRING_TOKEN = "LITERAL_STRING";
}