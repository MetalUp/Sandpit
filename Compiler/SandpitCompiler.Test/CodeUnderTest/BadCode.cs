namespace SandpitCompiler.Test.CodeUnderTest;

public class BadCode {
    // code to test starts with <Code> expected message same id but ends with <Message> 

    public const string Code1 = @"
main
  var a = 1
endmain
";

    public const string Code1Message = "line 4:0 mismatched input 'endmain' expecting 'end main'";

    public const string Code2 = @"main
var a = 1
end main
main
var b = 1
end main
";

    public const string Code2Message = "more than one main";

    public const string Code3 = @"main
var a = 1
var b = c
end main
";

    public const string Code3Message = "(11,9): error CS0103: The name 'c' does not exist in the current context";

    public const string Code4 = @"
procedure p()
  var a = b
end procedure
";

    public const string Code4Message = "(6,19): error CS0103: The name 'b' does not exist in the current context";

    public const string Code5 = @"
procedure p()
  var a = 1
endprocedure
";

    public const string Code5Message = "line 4:0 mismatched input 'endprocedure' expecting 'end procedure'";

    public const string Code6 = @"
function p() : Integer
  var a = 1
  return a
end function
";

    public const string Code6Message = "line 3:2 mismatched input 'var' expecting {'let', 'return'}";

    public const string Code7 = @"
procedure p()
  let a = 1
end procedure
";

    public const string Code7Message = "line 3:2 mismatched input 'let' expecting {'var', 'while'}";

    public const string Code8 = @"
main
  while ""fred""
    var a = 1
  end while
end main
";

    public const string Code8Message = "control expression must be bool";

}