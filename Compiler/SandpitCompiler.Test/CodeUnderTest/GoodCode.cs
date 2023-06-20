using SandpitCompiler.AST;
using static SandpitCompiler.Test.TestHelpers;

namespace SandpitCompiler.Test.CodeUnderTest;

public static class GoodCode {
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
function f() : Integer
let a = 1
return a
end function
";

    public const string Code8Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static int f() { 
    var a = 1; 
    return a;
  }  
}";

    public const string Code9 = @"
procedure p(z : Integer)
var a = z
end procedure
";

    public const string Code9Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static void p(int z) { 
    var a = z; 
  }  
}";

    public const string Code10 = @"
function f() : Integer
return 1
end function
";

    public const string Code10Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static int f() { 
    return 1;
  }  
}";

    public const string Code11 = @"
function f(a : Integer) : Integer
return a
end function
";

    public const string Code11Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static int f(int a) { 
    return a;
  }  
}";

    public const string Code12 = @"
function f(a : Integer) : Integer
let b = a
return b
end function
";

    public const string Code12Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public static int f(int a) {
    var b = a;
    return b;
  }  
}";

    public static readonly ASTNode Code1AST = new FileNode(Empty<ConstDeclNode>(), Empty<ProcNode>(), Empty<FuncNode>(), MN(("a", "1")));

    public static readonly ASTNode Code2AST = new FileNode(Empty<ConstDeclNode>(), Empty<ProcNode>(), Empty<FuncNode>(), MN(("a", "1"), ("b", "a")));

    public static readonly ASTNode Code3AST = new FileNode(new[] { CDN("pi", "4") }, Empty<ProcNode>(), Empty<FuncNode>(), null);

    public static readonly ASTNode Code4AST = new FileNode(new[] { CDN("pi", "4"), CDN("e", "3") }, Empty<ProcNode>(), Empty<FuncNode>(), null);

    public static readonly ASTNode Code5AST = new FileNode(new[] { CDN("pi", "4") }, Empty<ProcNode>(), Empty<FuncNode>(), MN(("a", "pi")));

    public static readonly ASTNode Code6AST = new FileNode(new[] { CDN("pi", "4") }, Empty<ProcNode>(), Empty<FuncNode>(), MN(("a", "pi")));

    private static MainNode MN(params (string, string)[] vars) => new(vars.Select(t => new VarDeclNode(ValueNode(t.Item1), ValueNode(t.Item2))).ToArray());

    private static ConstDeclNode CDN(string id, string v) => new(ValueNode(id), ValueNode(v));
}