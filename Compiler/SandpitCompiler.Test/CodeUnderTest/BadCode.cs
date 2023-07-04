namespace SandpitCompiler.Test.CodeUnderTest;

public class BadCode {
    public const string Code1 = @"
main
  var a = 1
endmain
";

    // code to test starts with <Code> expected message same id but ends with <Message> 

    private static readonly string NL = Environment.GetEnvironmentVariable("APPVEYOR") is "True" ? @"\n" : @"\r\n";

    public static readonly string Code1Message = $"line 4:7 no viable alternative at input '{NL}endmain{NL}'";

    public const string Code2 = @"main
var a = 1
end main
main
var b = 1
end main
";

    public const string Code2Message = "line 1:0 extraneous input 'main' expecting {<EOF>, SOL}";

    public const string Code3 = @"main
    var a = 1
    var b = c
    end main
    ";

    public const string Code3Message = "line 1:0 extraneous input 'main' expecting {<EOF>, SOL}";

    public const string Code4 = @"
    procedure p()
      var a = b
    end procedure
    ";

    public const string Code4Message = "(12,19): error CS0103: The name 'b' does not exist in the current context";

    public const string Code5 = @"
    procedure p()
      var a = 1
    endprocedure
    ";

    public static readonly string Code5Message = $"line 4:16 no viable alternative at input '{NL}endprocedure{NL}'";

    public const string Code6 = @"
    function p() : Integer
      var a = 1
      return a
    end function
    ";

    public static readonly string Code6Message = $"line 2:15 no viable alternative at input '{NL}functionp()'";

    public const string Code7 = @"
    procedure p()
      let a = 1
    end procedure
    ";

    public const string Code7Message = "line 4:4 mismatched input 'end' expecting 'in'";

    public const string Code8 = @"
    main
      while ""fred""
        var a = 1
      end while
    end main
    ";

    public const string Code8Message = "control expression must be bool";
}