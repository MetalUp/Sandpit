using Antlr4.Runtime;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST;

namespace SandpitCompiler.Test;

[TestClass]
public class ASTTest {
    private static IEnumerable<T> Empty<T>() where T : ASTNode => Array.Empty<T>();

    private ASTNode Setup(string code) => Pipeline.GenerateAst(Pipeline.Parse(code));

    private static void AssertTreesEqual(ASTNode expected, ASTNode actual) => Assert.AreEqual(expected.ToStringTree(), actual.ToStringTree());

    private static ValueNode ValueNode(string v) => new(new CommonToken(1, v));

    [TestMethod]
    public void TestMain() {
        var ast = Setup(GoodCodeToTest.Code1);
        var testAst = new FileNode(Empty<ConstDeclNode>(), Empty<ProcNode>(), Empty<FuncNode>(), new MainNode(new VarDeclNode(ValueNode("a"), ValueNode("1"))));

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestMainMultipleVar() {
        var ast = Setup(GoodCodeToTest.Code2);
        var testAst = new FileNode(Empty<ConstDeclNode>(), Empty<ProcNode>(), Empty<FuncNode>(), new MainNode(new VarDeclNode(ValueNode("a"), ValueNode("1")), new VarDeclNode(ValueNode("b"), ValueNode("a"))));

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestConstant() {
        var ast = Setup(GoodCodeToTest.Code3);
        var testAst = new FileNode(new[] { new ConstDeclNode(ValueNode("pi"), ValueNode("4")) }, Empty<ProcNode>(), Empty<FuncNode>(), null);

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestConstants() {
        var ast = Setup(GoodCodeToTest.Code4);
        var testAst = new FileNode(new[] { new ConstDeclNode(ValueNode("pi"), ValueNode("4")), new ConstDeclNode(ValueNode("e"), ValueNode("3")) }, Empty<ProcNode>(), Empty<FuncNode>(), null);

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestConstantAndMain() {
        var ast = Setup(GoodCodeToTest.Code5);
        var testAst = new FileNode(new[] { new ConstDeclNode(ValueNode("pi"), ValueNode("4")) }, Empty<ProcNode>(), Empty<FuncNode>(), new MainNode(new VarDeclNode(ValueNode("a"), ValueNode("pi"))));

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestConstantAndMainWithEmptyLine() {
        var ast = Setup(GoodCodeToTest.Code6);
        var testAst = new FileNode(new[] { new ConstDeclNode(ValueNode("pi"), ValueNode("4")) }, Empty<ProcNode>(), Empty<FuncNode>(), new MainNode(new VarDeclNode(ValueNode("a"), ValueNode("pi"))));

        AssertTreesEqual(testAst, ast);
    }

    [TestMethod]
    public void TestProcedure() {
        var ast = Setup(GoodCodeToTest.Code7);
        var testAst = new FileNode(Empty<ConstDeclNode>(), new[] { new ProcNode(ValueNode("p"), new VarDeclNode(ValueNode("a"), ValueNode("1"))) },  Empty<FuncNode>(), null);

        AssertTreesEqual(testAst, ast);
    }
}