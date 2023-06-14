using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandpitCompiler.Test;

[TestClass]
public class CompileTest {
    private static Options Options(string fn = "") => new() { CompileCSharp = true, FileName = $"{fn}" };

    private static void AssertGeneratedCode(string fn, string expected) {
        var code = File.ReadAllText($"{fn}.cs");
        Assert.AreEqual(expected, code);
    }

    private static void TestGoodCode(string fn, string code, string result) {
        Pipeline.Handle(code, Options(fn));
        AssertGeneratedCode(fn, result);
    }

    private static void TestBadCode(string code, string message) {
        try {
            Pipeline.Handle(code, Options());
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual(message, e.InnerException?.Message);
        }
    }

    [TestMethod]
    public void TestMainDecl() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code1, GoodCodeToTest.Code1Result);
    }

    [TestMethod]
    public void TestMainDeclMultipleVars() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code2, GoodCodeToTest.Code2Result);
    }

    [TestMethod]
    public void TestConstDecl() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code3, GoodCodeToTest.Code3Result);
    }

    [TestMethod]
    public void TestConstDecls() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code4, GoodCodeToTest.Code4Result);
    }

    [TestMethod]
    public void TestConstAndMain() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code5, GoodCodeToTest.Code5Result);
    }

    [TestMethod]
    public void TestConstAndMainWithEmptyLine() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code6, GoodCodeToTest.Code6Result);
    }

    [TestMethod]
    public void TestProcDecl() {
        TestGoodCode(MethodBase.GetCurrentMethod()?.Name ?? "", GoodCodeToTest.Code7, GoodCodeToTest.Code7Result);
    }

    [TestMethod]
    public void TestMainDeclFail() {
        TestBadCode(BadCodeToTest.Code1, BadCodeToTest.Code1Message);
    }

    [TestMethod]
    public void TestMainDeclMultipleFail() {
        TestBadCode(BadCodeToTest.Code2, BadCodeToTest.Code2Message);
    }

    [TestMethod]
    public void TestMainDeclMultipleVarFail() {
        TestBadCode(BadCodeToTest.Code3, BadCodeToTest.Code3Message);
    }
}