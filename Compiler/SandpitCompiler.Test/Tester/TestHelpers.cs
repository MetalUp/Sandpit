using System.Reflection;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST;

namespace SandpitCompiler.Test;

public static partial class TestHelpers {
    public static IEnumerable<T> Empty<T>() where T : ASTNode => Array.Empty<T>();

    public static ValueNode ValueNode(string v) => new(new CommonToken(1, v));

    public static string GetValue(FieldInfo? f) => f?.GetValue(null) as string ?? "";

    public static Options Options(string fn = "") => new() { CompileCSharp = true, FileName = $"{fn}" };

    [GeneratedRegex("\\s+")]
    public static partial Regex MyRegex();

    public static string ClearWs(string inp) => MyRegex().Replace(inp, " ");

    public static void AssertGeneratedCode(string fn, string expected, bool ignoreWhiteSpace = true) {
        var code = File.ReadAllText($"{fn}.cs");

        code = ignoreWhiteSpace ? ClearWs(code) : code;
        expected = ignoreWhiteSpace ? ClearWs(expected) : expected;

        Assert.AreEqual(expected, code, $"{fn} Failed");
    }

    public static void AssertTreesEqual(ASTNode expected, ASTNode? actual, string id) => Assert.AreEqual(expected.ToStringTree(), actual?.ToStringTree(), $"{id} failed");
}