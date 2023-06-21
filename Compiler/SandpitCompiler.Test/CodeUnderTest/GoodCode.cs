using Antlr4.Runtime;
using SandpitCompiler.AST;

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

    public const string Code13 = @"
main
var a = ""fred""
end main
";

    public const string Code13Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  
}
public static class Program {
    private static void Main(string[] args) {
      var a = ""fred"";
    }
}";

    public const string Code14 = @"
constant name = ""bill"" 
";

    public const string Code14Result = @"using static GlobalConstants;

public static partial class GlobalConstants {
  public const string name = ""bill"";
}";

    public const string Code15 = @"
constant names = {""bill"",""ben""} 
";

    public const string Code15Result = @"using System.Collections.Generic;
using System.Collections.Immutable;
using static GlobalConstants;

public static partial class GlobalConstants {
   public static readonly IList<string> names = new List<string> { ""bill"",""ben"" }.ToImmutableList();
}";

    public static readonly ASTNode Code1AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), MN(("a", "1")));

    public static readonly ASTNode Code2AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), MN(("a", "1"), ("b", "a")));

    public static readonly ASTNode Code3AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), null);

    public static readonly ASTNode Code4AST = FN(ARR(CDN("pi", "4"), CDN("e", "3")), E<ProcNode>(), E<FuncNode>(), null);

    public static readonly ASTNode Code5AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), MN(("a", "pi")));

    public static readonly ASTNode Code6AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), MN(("a", "pi")));

    public static readonly ASTNode Code7AST = FN(E<ConstDeclNode>(), ARR(PN("p", E<(string, string)>(), BN(ARR(("a", "1"))))), E<FuncNode>(), null);

    public static readonly ASTNode Code8AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Integer", E<(string, string)>(), FBN("1", ARR(("a", "1"))))), null);

    public static readonly ASTNode Code9AST = FN(E<ConstDeclNode>(), ARR(PN("p", ARR(("z", "Integer")), BN(ARR(("a", "z"))))), E<FuncNode>(), null);

    public static readonly ASTNode Code10AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Integer", E<(string, string)>(), FBN("1", E<(string, string)>()))), null);

    public static readonly ASTNode Code11AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Integer", ARR(("a", "Integer")), FBN("a", E<(string, string)>()))), null);

    public static readonly ASTNode Code12AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Integer", ARR(("a", "Integer")), FBN("b", ARR(("b", "a"))))), null);

    public static readonly ASTNode Code13AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), MN(("a", "\"fred\"")));

    public static readonly ASTNode Code14AST = FN(ARR(CDN("name", "\"bill\"")), E<ProcNode>(), E<FuncNode>(), null);

    public static readonly ASTNode Code15AST = FN(ARR(CDN("names", new[] { "\"bill\"", "\"ben\"" })), E<ProcNode>(), E<FuncNode>(), null);

    #region AST DSL

    private static Func<IEnumerable<ConstDeclNode>, IEnumerable<ProcNode>, IEnumerable<FuncNode>, MainNode?, FileNode> FN => (a, b, c, d) => new FileNode(a, b, c, d);

    private static MainNode MN(params (string, string)[] vars) => new(vars.Select(t => VDN(t.Item1, t.Item2)).ToArray());

    private static ConstDeclNode CDN(string id, string v) => new(SVN(id), SVN(v));

    private static ConstDeclNode CDN(string id, string[] vs) => new(SVN(id), LN(vs));

    private static VarDeclNode VDN(string id, string v) => new(SVN(id), SVN(v));

    private static LetDeclNode LDN(string id, string v) => new(SVN(id), SVN(v));

    private static ParamNode PMN(string id, string v) => new(SVN(id), SVN(v));

    private static ProcNode PN(string id, (string, string)[] param, BodyNode body) => new(SVN(id), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), body);

    private static FuncBodyNode FBN(string ret, (string, string)[] lets) => new(SVN(ret), lets.Select(t => LDN(t.Item1, t.Item2)).ToArray());

    private static BodyNode BN((string, string)[] vars) => new(vars.Select(t => VDN(t.Item1, t.Item2)).ToArray());

    private static FuncNode FNN(string id, string typ, (string, string)[] param, FuncBodyNode body) => new(SVN(id), SVN(typ), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), body);

    private static T[] E<T>() => Array.Empty<T>();

    private static T[] ARR<T>(params T[] v) => v;

    private static ScalarValueNode SVN(string v) => new(new CommonToken(SandpitParser.INT, v));

    private static ListNode LN(string[] vs) => new(vs.Select(SVN).Cast<ValueNode>().ToArray());

    #endregion
}