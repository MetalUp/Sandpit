namespace SandpitCompiler.Test.CodeUnderTest;

public class BadCode {
    public const string Code1 = @"
main
  var a = 1
endmain
";

    public const string Code2 = @"main
var a = 1
end main
main
var b = 1
end main
";

    public const string Code2Message = "line 1:0 extraneous input 'main' expecting {<EOF>, NL}";

    public const string Code3 = @"main
    var a = 1
    var b = c
    end main
    ";

    public const string Code3Message = "line 1:0 extraneous input 'main' expecting {<EOF>, NL}";

    public const string Code4 = @"
    procedure p()
      var a = b
    end procedure
    ";

    public const string Code4Message = "(10,19): error CS0103: The name 'b' does not exist in the current context";

    public const string Code5 = @"
    procedure p()
      var a = 1
    endprocedure
    ";

    public const string Code6 = @"
    function p() : Integer
      var a = 1
      return a
    end function
    ";

    public const string Code7 = @"
    procedure p()
      let a = 1
    end procedure
    ";

    public const string Code7Message = "line 3:6 mismatched input 'let' expecting 'end'";

    public const string Code8 = @"
    main
      while ""fred""
        var a = 1
      end while
    end main
    ";

    public const string Code8Message = "control expression must be bool";

    public const string Code9 = @"
    function f() as Int
      var a = 1
      p()
      return a
    end function

    procedure p()
      var a = 1
    end procedure
    ";

    public const string Code9Message = "Cannot have procedure/system call in function";

    public const string Code10 = @"
    function f() as Int
      var a = 1
      print(""fred"")
      return a
    end function
    ";

    public const string Code10Message = "Cannot have procedure/system call in function";

    public const string Code11 = @"
    function f() as Int
      return 1
    end function

    function g() as Int
      f()
      return 1
    end function
    ";

    public const string Code11Message = "Cannot have unassigned expression";

    public const string Code12 = @"
    function f() as Int
      var a = 1
      a = ""fred""
      return a
    end function
    ";

    public const string Code12Message = "Cannot assign String to Int";

    private static readonly string NL = Environment.GetEnvironmentVariable("APPVEYOR") is "True" ? @"\n" : @"\r\n";

    public static readonly string Code1Message = "line 5:0 mismatched input '<EOF>' expecting 'end'";

    public static readonly string Code5Message = "line 5:4 mismatched input '<EOF>' expecting 'end'";

    public static readonly string Code6Message = $"line 2:17 no viable alternative at input '{NL}functionp():'";

    // code to test starts with <Code> expected message same id but ends with <Message> 
}