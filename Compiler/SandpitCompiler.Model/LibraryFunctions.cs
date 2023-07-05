namespace SandpitCompiler.Model;

public static class LibraryFunctions {
    private static readonly string assertFunction = @"
public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
";

    private static readonly string printFunction = @"
public static void print(string s) { System.Console.WriteLine(s); }
";

    private static readonly string containsFunction = @"
public static bool contains<T>(IEnumerable<T> arr, T item) { return System.Linq.Enumerable.Contains(arr, item); }
";

    public static readonly string AllLibraryFunctions = @$"
public static partial class GlobalConstants {{
{assertFunction}
{printFunction}
{containsFunction}
}}".Trim();
}