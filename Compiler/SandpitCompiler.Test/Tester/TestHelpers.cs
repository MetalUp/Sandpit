﻿using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandpitCompiler.AST.Node;

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

        Assert.AreEqual(expected, code, $"{fn} Failed");
    }

    public static void AssertTreesEqual(ASTNode expected, ASTNode? actual, string id) {
        try {
            Assert.AreEqual(expected.ToStringTree(), actual?.ToStringTree());
        }
        catch (AssertFailedException e) {
            Console.WriteLine($"{id} failed");
            Console.WriteLine(expected.ToStringTree() + " EXPECTED");
            Console.WriteLine(actual?.ToStringTree() + " ACTUAL");
        }
    }
}