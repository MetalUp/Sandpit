using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandpitCompiler.Test;

[TestClass]
public class CompileTest {
    private Options Options => new() { CompileCSharp = true };

    [TestMethod]
    public void TestMainDecl() {
        Pipeline.Handle(@"main
var a = 1
end main

", Options);
    }

    [TestMethod]
    public void TestMainDeclFail() {
        try {
            Pipeline.Handle(@"main
var a = 1
endmain

", Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual("line 3:0 extraneous input 'endmain' expecting {'end main', 'var'}", e.InnerException.Message);
        }
    }

    [TestMethod]
    public void TestMainDeclMultipleFail() {
        try {
            Pipeline.Handle(@"main
var a = 1
end main
main
var b = 1
end main

", Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual("more than one main", e.InnerException.Message);
        }
    }

    [TestMethod]
    public void TestMainDeclMultipleVars() {
        Pipeline.Handle(@"main
var a = 1
var b = a
end main

", Options);
    }

    [TestMethod]
    public void TestMainDeclMultipleVarFail() {
        try {
            Pipeline.Handle(@"main
var a = 1
var b = c
end main

", Options);
            Assert.Fail("Expect exception");
        }
        catch (AggregateException e) {
            Assert.AreEqual("(11,9): error CS0103: The name 'c' does not exist in the current context", e.InnerException.Message);
        }
    }

    [TestMethod]
    public void TestConstDecl() {
        Pipeline.Handle(@"constant pi = 3
", Options);
    }

    [TestMethod]
    public void TestConstDecls() {
        Pipeline.Handle(@"constant pi = 3
constant e = 4

", Options);
    }

    [TestMethod]
    public void TestConstAndMain() {
        Pipeline.Handle(@"constant pi = 3
main 
var a = pi
end main

", Options);
    }

    [TestMethod]
    public void TestConstAndMainWithEmptyLine() {
        Pipeline.Handle(@"constant pi = 3

main 
var a = pi
end main

", Options);
    }
}