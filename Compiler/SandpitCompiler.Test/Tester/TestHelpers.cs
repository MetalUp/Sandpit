using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.Test;

public static partial class TestHelpers {
    public static string GetValue(FieldInfo? f) => f?.GetValue(null) as string ?? "";

    public static Options Options(string fn = "") => new() { CompileCSharp = true, FileName = $"{fn}" };

    [GeneratedRegex("\\s+")]
    public static partial Regex MyRegex();

    public static string ClearWs(string inp) => MyRegex().Replace(inp, " ");

    public static void AssertGeneratedCode(string fn, string expected, bool ignoreWhiteSpace = true) {
        var code = File.ReadAllText($"{fn}.cs");

        code = ignoreWhiteSpace ? ClearWs(code) : code;
        expected = ignoreWhiteSpace ? ClearWs(expected) : expected;

        try {
            Assert.AreEqual(expected.Trim(), code.Trim(), $"{fn} Failed");
        }
        catch (AssertFailedException) {
            Console.WriteLine($"{fn} failed");
            //Console.WriteLine(expected + " EXPECTED");
            //Console.WriteLine(code + " ACTUAL");

            for (int i = 0; i < code.Length; i++)
            {
                var c = code[i];
                var e = expected[i];

                if (c != e) {
                    Console.WriteLine(code[i..] + " CODE");
                    Console.WriteLine(expected[i..] + " EXPECTED");
                    break;
                }


            }

            throw;
        }
    }

    public static void AssertTreesEqual(IASTNode expected, IASTNode? actual, string id) {
        try {
            Assert.AreEqual(expected.ToStringTree(), actual?.ToStringTree());
        }
        catch (AssertFailedException) {
            Console.WriteLine($"{id} failed");
            Console.WriteLine(expected.ToStringTree() + " EXPECTED");
            Console.WriteLine(actual?.ToStringTree() + " ACTUAL");
            throw;
        }
    }
}