namespace SandpitCompiler.Test;

public static class GoodCodeToTest {
    // code to test starts with <Code> expected result same id but ends with <Result> 


    public const string Code1 = @"
main
var a = 1
end main
";

    public const string Code1Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  
}
public static class Program {
    private static void Main(string[] args) {
      var a = 1;
    }
}";

    public const string Code2 = @"
main
var a = 1
var b = a
end main
";

    public const string Code2Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  
}
public static class Program {
    private static void Main(string[] args) {
      var a = 1;
      var b = a;
        
    }
}";


    public const string Code3 = @"
constant pi = 4 
";

    public const string Code3Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public const int pi = 4;
}";

    public const string Code4 = @"
constant pi = 4 
constant e = 3
";

    public const string Code4Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public const int pi = 4;
  public const int e = 3;
}";

    public const string Code5 = @"constant pi = 4
main
var a = pi
end main
";

    public const string Code5Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public const int pi = 4;
}
public static class Program {
    private static void Main(string[] args) {
      var a = pi;
        
    }
}";

    public const string Code6 = @"constant pi = 4

main
var a = pi
end main
";

    public const string Code6Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public const int pi = 4;
}
public static class Program {
    private static void Main(string[] args) {
      var a = pi;
        
    }
}";

    public const string Code7 = @"
procedure p()
var a = 1
end procedure
";

    public const string Code7Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static void p() { 
    var a = 1; 
  }  
}";

    public const string Code8 = @"
function f()
let a = 1
end function
";

    public const string Code8Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static void f() { 
    var a = 1; 
  }  
}";
}