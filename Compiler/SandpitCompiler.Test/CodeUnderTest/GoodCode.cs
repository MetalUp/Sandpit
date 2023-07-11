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
    constant names = {""bill"", ""ben""} 
    ";

    public const string Code15Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
     
      public static readonly IList<string> names = new List<string> { ""bill"", ""ben"" }.ToImmutableList();
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
    ";

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

    public const string Code27 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt

function setTargetIfGreen(attempt String, target String, n Int) as String -> 
    if attempt.isGreen(target, n) then target.setChar(n, '.') else target

function isYellow(attempt String, target String, n Int) as Bool -> target.contains(attempt[n])

function isAlreadyMarkedGreen(attempt String, n Int) as Bool -> attempt[n] is '*'

function setAttemptIfYellow(attempt String, target String, n Int) as String -> 
    if isAlreadyMarkedGreen(attempt, n) then attempt
    else if attempt.isYellow(target, n) then attempt.setChar(n, '+')
    else attempt.setChar(n, '_')
    ";

    public const string Code27Result = @"using System.Collections.Generic;
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

      public static bool isAlreadyMarkedGreen(string attempt, int n) {
        return attempt[n] == '*';
      }

      public static string setAttemptIfYellow(string attempt, string target, int n) {
        return isAlreadyMarkedGreen(attempt, n) 
        ? attempt
        : isYellow(attempt, target, n) 
          ? setChar(attempt, n, '+')
          : setChar(attempt, n, '_');
      }
    }";

    public const string Code28 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt

function setTargetIfGreen(attempt String, target String, n Int) as String -> 
    if attempt.isGreen(target, n) then target.setChar(n, '.') else target

function isYellow(attempt String, target String, n Int) as Bool -> target.contains(attempt[n])

function isAlreadyMarkedGreen(attempt String, n Int) as Bool -> attempt[n] is '*'

function setAttemptIfYellow(attempt String, target String, n Int) as String -> 
    if isAlreadyMarkedGreen(attempt, n) then attempt
    else if attempt.isYellow(target, n) then attempt.setChar(n, '+')
    else attempt.setChar(n, '_')

function setTargetIfYellow(attempt String, target String, n Int) as String  ->
    if attempt.isAlreadyMarkedGreen(n) then target
    else if attempt.isYellow(target, n) then target.setChar(target.indexOf(attempt[n]), '.')
    else target
    ";

    public const string Code28Result = @"using System.Collections.Generic;
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

      public static bool isAlreadyMarkedGreen(string attempt, int n) {
        return attempt[n] == '*';
      }

      public static string setAttemptIfYellow(string attempt, string target, int n) {
        return isAlreadyMarkedGreen(attempt, n) 
        ? attempt
        : isYellow(attempt, target, n) 
          ? setChar(attempt, n, '+')
          : setChar(attempt, n, '_');
      }

      public static string setTargetIfYellow(string attempt, string target, int n) {
        return isAlreadyMarkedGreen(attempt, n) 
        ? target
        : isYellow(attempt, target, n) 
          ? setChar(target, indexOf(target, attempt[n]), '.')
          : target;
      }
    }";

    public const string Code29 = @"
function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

function setChar(word String, n Int, newChar Char) as String -> 
    word[..n] + newChar + word[n+1..]

function setAttemptIfGreen(attempt String, target String, n Int) as String ->
    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt

function setTargetIfGreen(attempt String, target String, n Int) as String -> 
    if attempt.isGreen(target, n) then target.setChar(n, '.') else target

function isYellow(attempt String, target String, n Int) as Bool -> target.contains(attempt[n])

function isAlreadyMarkedGreen(attempt String, n Int) as Bool -> attempt[n] is '*'

function setAttemptIfYellow(attempt String, target String, n Int) as String -> 
    if isAlreadyMarkedGreen(attempt, n) then attempt
    else if attempt.isYellow(target, n) then attempt.setChar(n, '+')
    else attempt.setChar(n, '_')

function setTargetIfYellow(attempt String, target String, n Int) as String  ->
    if attempt.isAlreadyMarkedGreen(n) then target
    else if attempt.isYellow(target, n) then target.setChar(target.indexOf(attempt[n]), '.')
    else target

function evaluateGreens(attempt String, target String) as (String, String) ->
    range(5).reduce((attempt, target), _
    lambda a, x-> _
    (setAttemptIfGreen(a.attempt, a.target, x), setTargetIfGreen(a.attempt, a.target, x)))
    ";

    public const string Code29Result = @"using System.Collections.Generic;
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

      public static bool isAlreadyMarkedGreen(string attempt, int n) {
        return attempt[n] == '*';
      }

      public static string setAttemptIfYellow(string attempt, string target, int n) {
        return isAlreadyMarkedGreen(attempt, n) 
        ? attempt
        : isYellow(attempt, target, n) 
          ? setChar(attempt, n, '+')
          : setChar(attempt, n, '_');
      }

      public static string setTargetIfYellow(string attempt, string target, int n) {
        return isAlreadyMarkedGreen(attempt, n) 
        ? target
        : isYellow(attempt, target, n) 
          ? setChar(target, indexOf(target, attempt[n]), '.')
          : target;
      }

      public static (string, string) evaluateGreens(string attempt, string target) {
         return reduce(range(5), (attempt, target), (a, x) => (setAttemptIfGreen(a.attempt, a.target, x), setTargetIfGreen(a.attempt, a.target, x)));
      }
    }";

    public const string Code30 = @"
        constant tuple = (3, 1)
        ";

    public const string Code30Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

        public static partial class GlobalConstants {
       
          public static readonly (int, int) tuple = (3, 1);
        }";

    public const string Code31 = @"
        function f(tuple (Int, Int)) as Bool ->
           let (a, b) = tuple in 
              a is b
        ";

    public const string Code31Result = @"using System.Collections.Generic;
    using System.Collections.Immutable;
    using static GlobalConstants;

    public static partial class GlobalConstants {
       public static bool f((int, int) tuple) { 
          return new System.Func<bool>(() => {
            var (a, b) = tuple;
            return a == b;
        })();
       } 
          
    }";

//    public const string Code32 = @"
//function isGreen(attempt String, target String, n Int) as Bool -> target[n] is attempt[n]

//function setChar(word String, n Int, newChar Char) as String -> 
//    word[..n] + newChar + word[n+1..]

//function setAttemptIfGreen(attempt String, target String, n Int) as String ->
//    if attempt.isGreen(target, n) then attempt.setChar(n, '*') else attempt

//function setTargetIfGreen(attempt String, target String, n Int) as String -> 
//    if attempt.isGreen(target, n) then target.setChar(n, '.') else target

//function isYellow(attempt String, target String, n Int) as Bool -> target.contains(attempt[n])

//function isAlreadyMarkedGreen(attempt String, n Int) as Bool -> attempt[n] is '*'

//function setAttemptIfYellow(attempt String, target String, n Int) as String -> 
//    if isAlreadyMarkedGreen(attempt, n) then attempt
//    else if attempt.isYellow(target, n) then attempt.setChar(n, '+')
//    else attempt.setChar(n, '_')

//function setTargetIfYellow(attempt String, target String, n Int) as String  ->
//    if attempt.isAlreadyMarkedGreen(n) then target
//    else if attempt.isYellow(target, n) then target.setChar(target.indexOf(attempt[n]), '.')
//    else target

//function evaluateGreens(attempt String, target String) as (String, String) ->
//    range(5).reduce((attempt, target), _
//    lambda a, x-> _
//    (setAttemptIfGreen(a.attempt, a.target, x), setTargetIfGreen(a.attempt, a.target, x)))

//function evaluateYellows(attempt String, target String) as (String, String) ->
//    range(5).reduce((attempt, target), _
//    lambda a, x -> (setAttemptIfYellow(a.attempt, t.target, x), setTargetIfYellow(a.attempt, t.target, x)))

//function markAttempt(attempt String, target String) as String ->
//    let (attemptAfterGreens, x) = evaluateGreens(attempt, target) in
//    attemptAfterGreens.evaluateYellows(targetAfterGreens)[0]
//    ";

//    public const string Code32Result = @"using System.Collections.Generic;
//    using System.Collections.Immutable;
//    using static GlobalConstants;

//    public static partial class GlobalConstants {
    
//      public static bool isGreen(string attempt, string target, int n) {
//        return target[n] == attempt[n];
//      } 

//      public static string setChar(string word, int n, char newChar) {
//        return word[..(n)] + newChar + word[(n + 1)..];
//      }

//      public static string setAttemptIfGreen(string attempt, string target, int n) {
//        return isGreen(attempt, target, n) ? setChar(attempt, n, '*') : attempt;
//      }

//      public static string setTargetIfGreen(string attempt, string target, int n) {
//        return isGreen(attempt, target, n) ? setChar(target, n, '.') : target;
//      }

//      public static bool isYellow(string attempt, string target, int n) {
//        return contains(target, attempt[n]);
//      }

//      public static bool isAlreadyMarkedGreen(string attempt, int n) {
//        return attempt[n] == '*';
//      }

//      public static string setAttemptIfYellow(string attempt, string target, int n) {
//        return isAlreadyMarkedGreen(attempt, n) 
//        ? attempt
//        : isYellow(attempt, target, n) 
//          ? setChar(attempt, n, '+')
//          : setChar(attempt, n, '_');
//      }

//      public static string setTargetIfYellow(string attempt, string target, int n) {
//        return isAlreadyMarkedGreen(attempt, n) 
//        ? target
//        : isYellow(attempt, target, n) 
//          ? setChar(target, indexOf(target, attempt[n]), '.')
//          : target;
//      }

//      public static (string, string) evaluateGreens(string attempt, string target) {
//         return reduce(range(5), (attempt, target), (a, x) => (setAttemptIfGreen(a.attempt, a.target, x), setTargetIfGreen(a.attempt, a.target, x)));
//      }

//      public static (string, string) evaluateYellows(string attempt, string target) {
//         return reduce(range(5), (attempt, target), (a, x) => (setAttemptIfYellow(a.attempt, a.target, x), setTargetIfYellow(a.attempt, a.target, x)));
//      }
//    }";



    public static readonly ASTNode Code1AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "1"))));

    public static readonly ASTNode Code2AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "1"), VDN("b", "a"))));

    public static readonly ASTNode Code3AST = FN(ARR(CDN("pi", "4")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code4AST = FN(ARR(CDN("pi", "4"), CDN("e", "3")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code5AST = FN(ARR(CDN("pi", "4")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code6AST = FN(ARR(CDN("pi", "4")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "pi"))));

    public static readonly ASTNode Code7AST = FN(E<ConstDefinitionNode>(), ARR(PN("p", E<(string, string)>(), VDN("a", "1"))), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code8AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), ARR(FNN("f", "Int", ARR(("a", "Int")), E<IStatement>(), "a")), E<MainNode>());

    public static readonly ASTNode Code9AST = FN(E<ConstDefinitionNode>(), ARR(PN("p", ARR(("z", "Int")), VDN("a", "z"))), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code10AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), ARR(FNN("f", "Int", ARR(("a", "Int")), E<IStatement>(), "1")), E<MainNode>());

    public static readonly ASTNode Code11AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), ARR(FNN("f", "Int", ARR(("a", "Int")), E<IStatement>(), "a")), E<MainNode>());

    public static readonly ASTNode Code12AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), ARR(FNN("f", "Int", ARR(("a", "Int")), ARR(VDN("b", "a")), "b")), E<MainNode>());

    public static readonly ASTNode Code13AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "\"fred\""))));

    public static readonly ASTNode Code14AST = FN(ARR(CDN("name", "\"bill\"")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code15AST = FN(ARR(CDN("names", "\"bill\"", "\"ben\"")), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), E<MainNode>());

    public static readonly ASTNode Code16AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(WN(SVN("true"), VDN("a", "1")))));

    public static readonly ASTNode Code17AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "1"), WN(BON(OVN(SandpitLexer.OP_EQ, "=="), SVN("a"), SVN("1")), VDN("b", "1")))));

    public static readonly ASTNode Code18AST = FN(E<ConstDefinitionNode>(), ARR(PN("printtest", ARR(("s", "String")), VDN("a", "s"))), E<FunctionDefinitionNode>(), ARR(MN(PSN("printtest", "\"test\""))));

    public static readonly ASTNode Code19AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(PSN("print", "\"test string\""))));

    public static readonly ASTNode Code20AST = FN(E<ConstDefinitionNode>(), E<ProcedureDefinitionNode>(), E<FunctionDefinitionNode>(), ARR(MN(VDN("a", "1"), WN(BON(OVN(SandpitLexer.OP_NE, "is not"), SVN("a"), SVN("2")), VDN("b", "1")))));

    #region AST DSL

    private static Func<IEnumerable<ConstDefinitionNode>, IEnumerable<ProcedureDefinitionNode>, IEnumerable<FunctionDefinitionNode>, IEnumerable<MainNode>, FileNode> FN => (a, b, c, d) => new FileNode(a, b, c, d);

    private static AggregateNode<T> AN<T>(params T[] nodes) where T : IASTNode => new(nodes);

    private static MainNode MN(params IStatement[] stats) => new(AN(stats));

    private static IStatement WN(IExpression vn, params IStatement[] stats) => new WhileStatementNode(vn, AN(stats));

    private static IStatement PSN(string id, params string[] parms) => new ProcedureStatementNode(SVN(id), parms.Select(SVN).ToArray());

    private static ConstDefinitionNode CDN(string id, string v) => new(SVN(id), SVN(v));

    private static ConstDefinitionNode CDN(string id, params string[] vs) => new(SVN(id), LN(vs));

    private static IStatement VDN(string id, string v) => new VarDefinitionNode(SVN(id), SVN(v));

    //private static IStatement LDN(string id, string v) => new LetDefnNode(SVN(id), SVN(v));

    private static ParameterDefinitionNode PMN(string id, string v) => new(SVN(id), TN(v));

    private static ProcedureDefinitionNode PN(string id, (string, string)[] param, params IStatement[] stats) => new(SVN(id), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), AN(stats));

    private static FunctionDefinitionNode FNN(string id, string typ, (string, string)[] param, IStatement[] stats, string v) => new(SVN(id), TN(typ), param.Select(t => PMN(t.Item1, t.Item2)).ToArray(), AN(stats), SVN(v));

    private static T[] E<T>() => Array.Empty<T>();

    private static T[] ARR<T>(params T[] v) => v;

    private static ValueNode SVN(string v) => new ScalarValueNode(new CommonToken(SandpitParser.LITERAL_INTEGER, v));

    private static TypeNode TN(string v) => new BuiltInTypeNode(new CommonToken(SandpitParser.LITERAL_INTEGER, v));

    private static OperatorValueNode OVN(int type, string v) => new(new CommonToken(type, v));

    private static ListExpressionNode LN(params string[] vs) => new(vs.Select(SVN).ToArray());

    private static IExpression BON(OperatorValueNode op, IExpression lhs, IExpression rhs) => new BinaryExpressionNode(op, lhs, rhs);

    #endregion
}