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

    // TODO do we need lazy impl
    private static readonly string indexOfFunction = @"
public static int indexOf<T>(IEnumerable<T> arr, T item) { return System.Linq.Enumerable.ToList(arr).IndexOf(item); }
";

    private static readonly string rangeFunction = @"
    public static IEnumerable<int> range(int i) {  return System.Linq.Enumerable.Range(0, i); }
";

    private static readonly string reduceFunction = @"
    public static TAccumulate reduce<TSource, TAccumulate>(IEnumerable<TSource> source, TAccumulate seed, System.Func<TAccumulate, TSource, TAccumulate> func) {
        return System.Linq.Enumerable.Aggregate(source, seed, func);
    }
";

    public static readonly string AllLibraryFunctions = @$"
public static partial class GlobalConstants {{
{assertFunction}
{printFunction}
{containsFunction}
{indexOfFunction}
{rangeFunction}
{reduceFunction}
}}".Trim();
}