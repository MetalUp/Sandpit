using SandpitCompiler.AST;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandpitCompiler.Test;

[TestClass]
public class ASTTest {
    private ASTNode Setup(string code) => Pipeline.GenerateAst(Pipeline.Parse(code));

    [TestMethod]
    public void TestMain() {
        var ast = Setup(@"main
var a = 1
end main

");

        Assert.AreEqual("(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, '1'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestMainMultipleVar() {
        var ast = Setup(@"main
var a = 1
var b = a
end main

");

        Assert.AreEqual("(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, '1'>) (VarDeclNode <ValueNode, 'b'><ValueNode, 'a'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstant() {
        var ast = Setup(@"constant pi = 4
");

        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>)", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstants() {
        var ast = Setup(@"constant pi = 4
constant e = 3

");

        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>) (ConstDeclNode <ValueNode, 'e'><ValueNode, '3'>)", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstantAndMain() {
        var ast = Setup(@"constant pi = 4
main
var a = pi
end main
");

        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>)(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, 'pi'>))", ast.ToStringTree());
    }
}