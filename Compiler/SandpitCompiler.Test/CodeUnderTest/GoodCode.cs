﻿using Antlr4.Runtime;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using System.Net.NetworkInformation;

namespace SandpitCompiler.Test.CodeUnderTest;

public static class GoodCode {
    // code to test starts with <Code> expected result same id but ends with <Result> 

    public const string Code1 = @"
main
var a = 1
end main
";

    public const string Code1Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code2Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code3Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

        public static partial class GlobalConstants {
         
          public const int pi = 4;
        }";

    public const string Code4 = @"
        constant pi = 4 
        constant e = 3
        ";

    public const string Code4Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

        public static partial class GlobalConstants {
         
          public const int pi = 4;
          public const int e = 3;
        }";

    public const string Code5 = @"
        constant pi = 4
        main
        var a = pi
        end main
        ";

    public const string Code5Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

        public static partial class GlobalConstants {
       
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

    public const string Code6Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code7Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
     
      public static void p() { 
        var a = 1; 
      }  
    }";

    public const string Code8 = @"
    function f(a Int) as Int -> a
    ";

    public const string Code8Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
      public static int f(int a) { 
        return a;
      }  
    }";

    public const string Code9 = @"
    procedure p(z Int)
    var a = z
    end procedure
    ";

    public const string Code9Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
     
      public static void p(int z) { 
        var a = z; 
      }  
    }";

    public const string Code10 = @"
    function f(a Int) as Int
    return 1
    end function
    ";

    public const string Code10Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
      
      public static int f(int a) { 
        return 1;
      }  
    }";

    public const string Code11 = @"
    function f(a  Int) as Int
    return a
    end function
    ";

    public const string Code11Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
     
      public static int f(int a) { 
        return a;
      }  
    }";

    public const string Code12 = @"
    function f(a Int) as Int
    var b = a
    return b
    end function
    ";

    public const string Code12Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code13Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code14Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

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

    public const string Code16 = @"
    main
    while true
      var a = 1
    end while 
    end main
    ";

    public const string Code16Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
     
    }
    public static class Program {
        private static void Main(string[] args) {
          while (true) {
            var a = 1;
          }
        }
    }";

    public const string Code17 = @"
    main
    var a = 1
    while a == 1
      var b = 1
    end while 
    end main
    ";

    public const string Code17Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
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

    public const string Code18Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
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
    "
    ;

    public const string Code19Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
  
    }
    public static class Program {
        private static void Main(string[] args) {
          print(""test string"");
        }
    }";

    public const string Code20 = @"
    main
      var a = 1
      while a is not 2
        var b = 1
      end while 
    end main
    ";

    public const string Code20Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
    }
    public static class Program {
        private static void Main(string[] args) {
          var a = 1;
          while (a != 2) {
            var b = 1;
          }
        }
    }";

    public const string Code21 = @"
function bestAttempt(possAnswers Iterable<String>, possAttempts List<String>) as String -> """"
    ";

    public const string Code21Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
      public static string bestAttempt(IEnumerable<string> possAnswers, IList<string> possAttempts) {
        return """";
      } 
    }";

    public const string Code22 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]
    ";

    public const string Code22Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    

      public static bool isGreen(string attempt, string target, int n) {
        return target[n] == attempt[n];
      } 
    }";

    public const string Code23 = @"
function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]
    ";

    public const string Code23Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    

      public static string setChar(string word, int n, char newChar) {
        return word[..(n)] + newChar + word[(n + 1)..];
      } 
    }";

    public const string Code24 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if isGreen(attempt, target, n) then setChar(attempt, n, '*') else attempt
    ";

    public const string Code24Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    

      public static bool isGreen(string attempt, string target, int n) {
        return target[n] == attempt[n];
      } 

      public static string setChar(string word, int n, char newChar) {
        return word[..(n)] + newChar + word[(n + 1)..];
      }

      public static string setAttemptIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(attempt, n, '*') : attempt;
      }
    }";

    public const string Code25 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt
    ";

    public const string Code25Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    

      public static bool isGreen(string attempt, string target, int n) {
        return target[n] == attempt[n];
      } 

      public static string setChar(string word, int n, char newChar) {
        return word[..(n)] + newChar + word[(n + 1)..];
      }

      public static string setAttemptIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(attempt, n, '*') : attempt;
      }
    }";

    public const string Code26 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt

function setTargetIfGreen(attempt String, target String, n Int) as String -> 
    if attempt.isGreen(target, n) then target.setChar(n, '.') else target

function isYellow(attempt String, target String, n Int) as Bool -> target.contains(attempt[n])
    ";

    public const string Code26Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
    
      public static bool isGreen(string attempt, string target, int n) {
        return target[n] == attempt[n];
      } 

      public static string setChar(string word, int n, char newChar) {
        return word[..(n)] + newChar + word[(n + 1)..];
      }

      public static string setAttemptIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(attempt, n, '*') : attempt;
      }

      public static string setTargetIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(target, n, '.') : target;
      }

      public static bool isYellow(string attempt, string target, int n) {
        return contains(target, attempt[n]);
      }
    }";

    public static readonly ASTNode Code1AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "1"))));

    public static readonly ASTNode Code2AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "1"), VDN("b", "a"))));

    public static readonly ASTNode Code3AST = FN(ARR(CDN("pi", "4")), E<ProcDefnNode>(), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code4AST = FN(ARR(CDN("pi", "4"), CDN("e", "3")), E<ProcDefnNode>(), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code5AST = FN(ARR(CDN("pi", "4")), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code6AST = FN(ARR(CDN("pi", "4")), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code7AST = FN(E<ConstDefnNode>(), ARR(PN("p", E<(string, string)>(), VDN("a", "1"))), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code8AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), ARR(FNN("f", "Int", E<(string, string)>(), ARR(LDN("a", "1")), "1")), E<MainNode>());

    public static readonly ASTNode Code9AST = FN(E<ConstDefnNode>(), ARR(PN("p", ARR(("z", "Int")), VDN("a", "z"))), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code10AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), ARR(FNN("f", "Int", E<(string, string)>(), E<StatNode>(), "1")), E<MainNode>());

    public static readonly ASTNode Code11AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), ARR(FNN("f", "Int", E<(string, string)>(), E<StatNode>(), "a")), E<MainNode>());

    public static readonly ASTNode Code12AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), ARR(FNN("f", "Int", ARR(("a", "Int")), E<StatNode>(), "a")), E<MainNode>());

    public static readonly ASTNode Code13AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "\"fred\""))));

    public static readonly ASTNode Code14AST = FN(ARR(CDN("name", "\"bill\"")), E<ProcDefnNode>(), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code15AST = FN(ARR(CDN("names", "\"bill\"", "\"ben\"")), E<ProcDefnNode>(), E<FuncDefnNode>(), E<MainNode>());

    public static readonly ASTNode Code16AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(WN(SVN("true"), VDN("a", "1")))));

    public static readonly ASTNode Code17AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "1"), WN(BON(OVN(SandpitLexer.OP_EQ, "=="), SVN("a"), SVN("1")), VDN("b", "1")))));

    public static readonly ASTNode Code18AST = FN(E<ConstDefnNode>(), ARR(PN("printtest", ARR(("s", "String")), VDN("a", "s"))), E<FuncDefnNode>(), ARR(MN(PSN("printtest", "\"test\""))));

    public static readonly ASTNode Code19AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(PSN("print", "\"test string\""))));

    public static readonly ASTNode Code20AST = FN(E<ConstDefnNode>(), E<ProcDefnNode>(), E<FuncDefnNode>(), ARR(MN(VDN("a", "1"), WN(BON(OVN(SandpitLexer.OP_NE,  "is not"), SVN("a"), SVN("2")), VDN("b", "1")))));

    #region AST DSL

    private static Func<IEnumerable<ConstDefnNode>, IEnumerable<ProcDefnNode>, IEnumerable<FuncDefnNode>, IEnumerable<MainNode>, FileNode> FN => (a, b, c, d) => new FileNode(a, b, c, d);

    private static AggregateNode<T> AN<T>(params T[] nodes) where T : IASTNode => new(nodes);

    private static MainNode MN(params StatNode[] stats) => new(AN(stats));

    private static StatNode WN(ValueNode vn, params StatNode[] stats) => new WhileStatNode(vn, AN(stats));

    private static StatNode PSN(string id, params string[] parms) => new ProcStatNode(SVN(id), parms.Select(SVN).ToArray());

    private static ConstDefnNode CDN(string id, string v) => new(SVN(id), SVN(v));

    private static ConstDefnNode CDN(string id, params string[] vs) => new(SVN(id), LN(vs));

    private static StatNode VDN(string id, string v) => new VarDefnNode(SVN(id), SVN(v));

    private static StatNode LDN(string id, string v) => new LetDefnNode(SVN(id), SVN(v));

    private static ParamDefnNode PMN(string id, string v) => new(SVN(id), TN(v));

    private static ProcDefnNode PN(string id, (string, string)[] param, params StatNode[] stats) => new(SVN(id), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), AN(stats));

    private static FuncDefnNode FNN(string id, string typ, (string, string)[] param, StatNode[] stats, string v) => new(SVN(id), TN(typ), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), AN(stats), SVN(v));

    private static T[] E<T>() => Array.Empty<T>();

    private static T[] ARR<T>(params T[] v) => v;

    private static ValueNode SVN(string v) => new ScalarValueNode(new CommonToken(SandpitParser.LITERAL_INTEGER, v));

    private static TypeNode TN(string v) => new BuiltInTypeNode(new CommonToken(SandpitParser.LITERAL_INTEGER, v));

    private static OperatorValueNode OVN(int type, string v) => new OperatorValueNode(new CommonToken(type, v));

    private static ListValueNode LN(params string[] vs) => new(vs.Select(SVN).ToArray());

    private static ValueNode BON(OperatorValueNode op, ValueNode lhs, ValueNode rhs) => new BinaryValueNode(op, lhs, rhs);

    #endregion

}