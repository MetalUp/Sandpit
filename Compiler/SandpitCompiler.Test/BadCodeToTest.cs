﻿namespace SandpitCompiler.Test;

public class BadCodeToTest {
    // code to test starts with <Code> expected message same id but ends with <Message> 


    public const string Code1 = @"
main
  var a = 1
endmain
";

    public const string Code1Message = "line 4:0 extraneous input 'endmain' expecting {'end main', 'var'}";

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

    public const string Code3Message = "(10,15): error CS0103: The name 'c' does not exist in the current context";

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

    public const string Code5Message = "line 4:0 extraneous input 'endprocedure' expecting {'end procedure', 'var'}";
}