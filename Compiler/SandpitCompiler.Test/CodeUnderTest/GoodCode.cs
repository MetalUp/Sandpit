using Antlr4.Runtime;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;

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
  public static void print(string s) { System.Console.WriteLine(s); }
  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
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
  public static void print(string s) { System.Console.WriteLine(s); }
  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
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
          public static void print(string s) { System.Console.WriteLine(s); }
          public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
          public const int pi = 4;
        }";

    public const string Code4 = @"
        constant pi = 4 
        constant e = 3
        ";

    public const string Code4Result = @"using static GlobalConstants;

        public static partial class GlobalConstants {
          public static void print(string s) { System.Console.WriteLine(s); }
          public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
          public const int pi = 4;
          public const int e = 3;
        }";

    public const string Code5 = @"
        constant pi = 4
        main
        var a = pi
        end main
        ";

    public const string Code5Result = @"using static GlobalConstants;

        public static partial class GlobalConstants {
          public static void print(string s) { System.Console.WriteLine(s); }
          public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
          public const int pi = 4;
        }
        public static class Program {
            private static void Main(string[] args) {
              var a = pi;

            }
        }";

    public const string Code6 = @"
        constant pi = 4

        main
        var a = pi
        end main
        ";

    public const string Code6Result = @"using static GlobalConstants;

        public static partial class GlobalConstants {
          public static void print(string s) { System.Console.WriteLine(s); }
          public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
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
      public static void print(string s) { System.Console.WriteLine(s); }
      public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
      public static void p() { 
        var a = 1; 
      }  
    }";

    //public const string Code8 = @"
    //function f(a Int) -> Int a
    //";

    //public const string Code8Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public static int f() { 
    //    var a = 1; 
    //    return a;
    //  }  
    //}";

    public const string Code9 = @"
    procedure p(z Int)
    var a = z
    end procedure
    ";

    public const string Code9Result = @"using static GlobalConstants;

    public static partial class GlobalConstants {
      public static void print(string s) { System.Console.WriteLine(s); }
      public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
      public static void p(int z) { 
        var a = z; 
      }  
    }";

    //public const string Code10 = @"
    //function f(a Int) -> Int
    //return 1
    //end function
    //";

    //public const string Code10Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public static int f() { 
    //    return 1;
    //  }  
    //}";

    //public const string Code11 = @"
    //function f(a  Int) as Int
    //return a
    //end function
    //";

    //public const string Code11Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public static int f(int a) { 
    //    return a;
    //  }  
    //}";

    //    public const string Code12 = @"
    //function f(a : Integer) : Integer
    //let b = a
    //return b
    //end function
    //";

    //    public const string Code12Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public static int f(int a) {
    //    var b = a;
    //    return b;
    //  }  
    //}";

    //    public const string Code13 = @"
    //main
    //var a = ""fred""
    //end main
    //";

    //    public const string Code13Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //}
    //public static class Program {
    //    private static void Main(string[] args) {
    //      var a = ""fred"";
    //    }
    //}";

    //    public const string Code14 = @"
    //constant name = ""bill"" 
    //";

    //    public const string Code14Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public const string name = ""bill"";
    //}";

    //    public const string Code15 = @"
    //constant names = {""bill"",""ben""} 
    //";

    //    public const string Code15Result = @"using System.Collections.Generic;
    //using System.Collections.Immutable;
    //using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //  public static readonly IList<string> names = new List<string> { ""bill"",""ben"" }.ToImmutableList();
    //}";

    //public const string Code16 = @"
    //main
    //while true
    //  var a = 1
    //end while 
    //end main
    //";

    //public const string Code16Result = @"using static GlobalConstants;

    //public static partial class GlobalConstants {
    //  public static void print(string s) { System.Console.WriteLine(s); }
    //  public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    //}
    //public static class Program {
    //    private static void Main(string[] args) {
    //      while (true) {
    //        var a = 1;
    //      }
    //    }
    //}";

    public const string Code17 = @"
    main
    var a = 1
    while a == 1
      var b = 1
    end while 
    end main
    ";

    public const string Code17Result = @"using static GlobalConstants;

    public static partial class GlobalConstants {
      public static void print(string s) { System.Console.WriteLine(s); }
      public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    }
    public static class Program {
        private static void Main(string[] args) {
          var a = 1;
          while (a == 1) {
            var b = 1;
          }
        }
    }";

    public const string Code18 = @"
    procedure printtest(s String)
    var a = s
    end procedure

    main
      printtest(""test"")
    end main
    ";

    public const string Code18Result = @"using static GlobalConstants;

    public static partial class GlobalConstants {
      public static void print(string s) { System.Console.WriteLine(s); }
      public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
      public static void printtest(string s) { 
        var a = s; 
      }
    }
    public static class Program {
        private static void Main(string[] args) {
          printtest(""test"");
        }
    }";

    public const string Code19 = @"
    main
      print(""test string"")
    end main
    ";

    public const string Code19Result = @"using static GlobalConstants;

    public static partial class GlobalConstants {
      public static void print(string s) { System.Console.WriteLine(s); }
      public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
    }
    public static class Program {
        private static void Main(string[] args) {
          print(""test string"");
        }
    }";

    public static readonly ASTNode Code1AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "1"))));

    public static readonly ASTNode Code2AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "1"), VDN("b", "a"))));

    public static readonly ASTNode Code3AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code4AST = FN(ARR(CDN("pi", "4"), CDN("e", "3")), E<ProcNode>(), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code5AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code6AST = FN(ARR(CDN("pi", "4")), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code7AST = FN(E<ConstDeclNode>(), ARR(PN("p", E<(string, string)>(), VDN("a", "1"))), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code8AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Int", FBN("1", ("a", "1")), E<(string, string)>())), E<MainNode>());

    public static readonly ASTNode Code9AST = FN(E<ConstDeclNode>(), ARR(PN("p", ARR(("z", "Int")), VDN("a", "z"))), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code10AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Int", FBN("1", E<(string, string)>()), E<(string, string)>())), E<MainNode>());

    public static readonly ASTNode Code11AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Int", FBN("a", E<(string, string)>()), ("a", "Int"))), E<MainNode>());

    public static readonly ASTNode Code12AST = FN(E<ConstDeclNode>(), E<ProcNode>(), ARR(FNN("f", "Int", FBN("b", ("b", "a")), ("a", "Int"))), E<MainNode>());

    public static readonly ASTNode Code13AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "\"fred\""))));

    public static readonly ASTNode Code14AST = FN(ARR(CDN("name", "\"bill\"")), E<ProcNode>(), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code15AST = FN(ARR(CDN("names", "\"bill\"", "\"ben\"")), E<ProcNode>(), E<FuncNode>(), E<MainNode>());

    public static readonly ASTNode Code16AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), ARR(MN(WN(SVN("true"), VDN("a", "1")))));

    public static readonly ASTNode Code17AST = FN(E<ConstDeclNode>(), E<ProcNode>(), E<FuncNode>(), ARR(MN(VDN("a", "1"), WN(BON(SVN("=="), SVN("a"), SVN("1")), VDN("b", "1")))));

    public static readonly ASTNode Code18AST = FN(E<ConstDeclNode>(), ARR(PN("printtest", ARR(("s", "String")), VDN("a", "s"))), E<FuncNode>(), ARR(MN(PSN("printtest", "\"test\""))));

    #region AST DSL

    private static Func<IEnumerable<ConstDeclNode>, IEnumerable<ProcNode>, IEnumerable<FuncNode>, IEnumerable<MainNode>, FileNode> FN => (a, b, c, d) => new FileNode(a, b, c, d);

    private static AggregateNode<T> AN<T>(params T[] nodes) where T : IASTNode => new(nodes);

    private static MainNode MN(params StatNode[] stats) => new(AN(stats));

    private static StatNode WN(ValueNode vn, params StatNode[] stats) => new WhileNode(vn, AN(stats));

    private static StatNode PSN(string id, params string[] parms) => new ProcStatNode(SVN(id), parms.Select(SVN).ToArray());

    private static ConstDeclNode CDN(string id, string v) => new(SVN(id), SVN(v));

    private static ConstDeclNode CDN(string id, params string[] vs) => new(SVN(id), LN(vs));

    private static StatNode VDN(string id, string v) => new VarDeclNode(SVN(id), SVN(v));

    private static LetDeclNode LDN(string id, string v) => new(SVN(id), SVN(v));

    private static ParamNode PMN(string id, string v) => new(SVN(id), SVN(v));

    private static ProcNode PN(string id, (string, string)[] param, params StatNode[] stats) => new(SVN(id), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), AN(stats));

    private static FuncBodyNode FBN(string ret, params (string, string)[] lets) => new(SVN(ret), lets.Select(t => LDN(t.Item1, t.Item2)).ToArray());

    private static BodyNode BN(params StatNode[] statNodes) => new(statNodes);

    private static FuncNode FNN(string id, string typ, FuncBodyNode body, params (string, string)[] param) => new(SVN(id), SVN(typ), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), body);

    private static T[] E<T>() => Array.Empty<T>();

    private static T[] ARR<T>(params T[] v) => v;

    private static ValueNode SVN(string v) => new ScalarValueNode(new CommonToken(SandpitParser.LITERAL_INTEGER, v));

    private static ListNode LN(params string[] vs) => new(vs.Select(SVN).ToArray());

    private static ValueNode BON(ValueNode op, ValueNode lhs, ValueNode rhs) => new BinaryOperatorNode(op, lhs, rhs);

    #endregion
}