using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandpitCompiler.Test;

[TestClass]
public partial class CompileTest {
    private static Options Options(string fn = "") => new() { CompileCSharp = true, FileName = $"{fn}" };

    [GeneratedRegex("\\s+")]
    private static partial Regex MyRegex();

    private static string ClearWs(string inp) => MyRegex().Replace(inp, " ");

    private static void AssertGeneratedCode(string fn, string expected, bool ignoreWhiteSpace = true) {
        var code = File.ReadAllText($"{fn}.cs");

        code = ignoreWhiteSpace ? ClearWs(code) : code;
        expected = ignoreWhiteSpace ? ClearWs(expected) : expected;

        Assert.AreEqual(expected, code, $"{fn} Failed");
    }

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

    private static string GetValue(FieldInfo? f) => f?.GetValue(null) as string ?? "";

    [TestMethod]
    public void TestAllGoodCode() {
        var codeFields = typeof(GoodCodeToTest).GetFields().Where(f => f.Name.StartsWith("Code") && !f.Name.EndsWith("Result"));

        foreach (var codeField in codeFields) {
            var id = codeField.Name;
            var resultField = typeof(GoodCodeToTest).GetField($"{id}Result");
            var code = GetValue(codeField);
            var result = GetValue(resultField);

            TestGoodCode(id, code, result);

            Console.WriteLine($"Tested {id}");
        }
    }

    [TestMethod]
    public void TestAllBadCode() {
        var codeFields = typeof(BadCodeToTest).GetFields().Where(f => f.Name.StartsWith("Code") && !f.Name.EndsWith("Message"));

        foreach (var codeField in codeFields) {
            var id = codeField.Name;
            var msgField = typeof(BadCodeToTest).GetField($"{id}Message");
            var code = GetValue(codeField);
            var msg = GetValue(msgField);

            TestBadCode(id, code, msg);

            Console.WriteLine($"Tested {id}");
        }
    }

    
}