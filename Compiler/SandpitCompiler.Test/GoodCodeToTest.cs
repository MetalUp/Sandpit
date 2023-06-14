namespace SandpitCompiler.Test;

public static class GoodCodeToTest {
    public const string Code1 = @"
main
var a = 1
end main
";

    public const string Code2 = @"
main
var a = 1
var b = a
end main
";

    public const string Code3 = @"
constant pi = 4 
";

    public const string Code4 = @"
constant pi = 4 
constant e = 3
";

    public const string Code5 = @"constant pi = 4
main
var a = pi
end main
";

    public const string Code6 = @"constant pi = 4

main
var a = pi
end main
";
}