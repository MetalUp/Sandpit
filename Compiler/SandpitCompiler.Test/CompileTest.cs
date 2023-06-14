using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandpitCompiler.Test;

[TestClass]
public class CompileTest {
    private Options Options => new() { CompileCSharp = true };

    [TestMethod]
    public void TestMainDecl() {
        Pipeline.Handle(GoodCodeToTest.Code1, Options);
    }

    [TestMethod]
    public void TestMainDeclFail() {
        try {
            Pipeline.Handle(BadCodeToTest.Code1, Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual(BadCodeToTest.Code1Message, e.InnerException?.Message);
        }
    }

    [TestMethod]
    public void TestMainDeclMultipleFail() {
        try {
            Pipeline.Handle(BadCodeToTest.Code2, Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual(BadCodeToTest.Code2Message, e.InnerException?.Message);
        }
    }

    [TestMethod]
    public void TestMainDeclMultipleVars() {
        Pipeline.Handle(GoodCodeToTest.Code2, Options);
    }

    [TestMethod]
    public void TestMainDeclMultipleVarFail() {
        try {
            Pipeline.Handle(BadCodeToTest.Code3, Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual(BadCodeToTest.Code3Message, e.InnerException?.Message);
        }
    }

    [TestMethod]
    public void TestConstDecl() {
        Pipeline.Handle(GoodCodeToTest.Code3, Options);
    }

    [TestMethod]
    public void TestConstDecls() {
        Pipeline.Handle(GoodCodeToTest.Code4, Options);
    }

    [TestMethod]
    public void TestConstAndMain() {
        Pipeline.Handle(GoodCodeToTest.Code5, Options);
    }

    [TestMethod]
    public void TestConstAndMainWithEmptyLine() {
        Pipeline.Handle(GoodCodeToTest.Code6, Options);
    }
}