using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST.Node;
using SandpitCompiler.Test.CodeUnderTest;
using static SandpitCompiler.Test.TestHelpers;

namespace SandpitCompiler.Test.Tester;

[TestClass]
public class CompileTest {
    private ASTNode? CreateAST(string code) => Pipeline.GenerateAst(Pipeline.Parse(code));

    private static void TestGoodCode(string fn, string code, string result) {
        Pipeline.Handle(code, Options(fn));
        AssertGeneratedCode(fn, result);
    }

    private static void TestBadCode(string fn, string code, string message, bool ignoreWhiteSpace = true) {
        try {
            Pipeline.Handle(code, Options());
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual(ClearWs(message), ClearWs(e.InnerException?.Message ?? ""), $"{fn} Failed");
        }
    }

    private void TestASTs(IEnumerable<FieldInfo> codeFields) {
        foreach (var codeField in codeFields) {
            var id = codeField.Name;
            var resultField = typeof(GoodCode).GetField($"{id}AST");
            var code = GetValue(codeField);
            var ast = CreateAST(code);
            var expected = resultField?.GetValue(null) as ASTNode;

            if (expected is not null) {
                AssertTreesEqual(expected, ast, id);

                Console.WriteLine($"Tested AST {id}");
            }
        }
    }

    [TestMethod]
    public void TestAllGoodCode() {
        var codeFields = typeof(GoodCode).GetFields().Where(f => f.Name.StartsWith("Code") && !(f.Name.EndsWith("Result") || f.Name.EndsWith("AST")));

        foreach (var codeField in codeFields) {
            TestGoodCode(codeField);
        }
    }

    private static void TestGoodCode(FieldInfo codeField) {
        var id = codeField.Name;
        var resultField = typeof(GoodCode).GetField($"{id}Result");
        var code = GetValue(codeField);
        var result = GetValue(resultField);

        TestGoodCode(id, code, result);

        Console.WriteLine($"Tested {id}");
    }

    [TestMethod]
    public void TestAllBadCode() {
        var codeFields = typeof(BadCode).GetFields().Where(f => f.Name.StartsWith("Code") && !f.Name.EndsWith("Message"));

        foreach (var codeField in codeFields) {
            var id = codeField.Name;
            var msgField = typeof(BadCode).GetField($"{id}Message");
            var code = GetValue(codeField);
            var msg = GetValue(msgField);

            TestBadCode(id, code, msg);

            Console.WriteLine($"Tested {id}");
        }
    }

    [TestMethod]
    public void TestAllASTs() {
        var codeFields = typeof(GoodCode).GetFields().Where(f => f.Name.StartsWith("Code") && !(f.Name.EndsWith("Result") || f.Name.EndsWith("AST")));
        TestASTs(codeFields);
    }

    private void DebugHelperTestAST(string name) {
        var codeFields = typeof(GoodCode).GetFields().Where(f => f.Name == name);
        TestASTs(codeFields);
    }

    private void DebugHelperTestGoodCode(string name) {
        var codeFields = typeof(GoodCode).GetFields().Where(f => f.Name == name);
        TestGoodCode(codeFields.Single());
    }


    [TestMethod]
    public void DebugTestAST() {
        DebugHelperTestAST("Code22");
    }

    [TestMethod]
    public void DebugTestGoodCode() {
        DebugHelperTestGoodCode("Code1");
    }
}