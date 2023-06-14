using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST;

namespace SandpitCompiler.Test;

[TestClass]
public class ASTTest {
    private ASTNode Setup(string code) => Pipeline.GenerateAst(Pipeline.Parse(code));

    [TestMethod]
    public void TestMain() {
        var ast = Setup(GoodCodeToTest.Code1);
        Assert.AreEqual("(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, '1'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestMainMultipleVar() {
        var ast = Setup(GoodCodeToTest.Code2);
        Assert.AreEqual("(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, '1'>) (VarDeclNode <ValueNode, 'b'><ValueNode, 'a'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstant() {
        var ast = Setup(GoodCodeToTest.Code3);
        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>)", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstants() {
        var ast = Setup(GoodCodeToTest.Code4);
        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>) (ConstDeclNode <ValueNode, 'e'><ValueNode, '3'>)", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstantAndMain() {
        var ast = Setup(GoodCodeToTest.Code5);
        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>)(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, 'pi'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestConstantAndMainWithEmptyLine() {
        var ast = Setup(GoodCodeToTest.Code6);
        Assert.AreEqual("(ConstDeclNode <ValueNode, 'pi'><ValueNode, '4'>)(MainNode (VarDeclNode <ValueNode, 'a'><ValueNode, 'pi'>))", ast.ToStringTree());
    }

    [TestMethod]
    public void TestProcedure() {
        var ast = Setup(GoodCodeToTest.Code7);
        Assert.AreEqual("(ProcNode (VarDeclNode <ValueNode, 'a'><ValueNode, '1'>))", ast.ToStringTree());
    }
}