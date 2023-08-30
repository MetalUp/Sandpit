namespace SandpitCompiler.Model;

public static class LibraryFunctions {
    private static readonly string assertFunction = @"
public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
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

    private static readonly string reduceFunction1 = @"
    public static TSource reduce<TSource>(IEnumerable<TSource> source, System.Func<TSource, TSource, TSource> func) {
      return System.Linq.Enumerable.Aggregate(source, func);
    }
";

  

    private static readonly string filterFunction = @"
    public static IEnumerable<TSource> filter<TSource>(IEnumerable<TSource> source, System.Func<TSource, bool> predicate) {
        return System.Linq.Enumerable.Where(source, predicate);
    }
";

    private static readonly string mapFunction = @"
    public static IEnumerable<TResult> map<TSource, TResult>(IEnumerable<TSource> source, System.Func<TSource, TResult> predicate) {
        return System.Linq.Enumerable.Select(source, predicate);
    }
";

    private static readonly string  groupByFunction = @"
    public static IEnumerable<IEnumerable<TSource>> groupBy<TSource, TKey>(IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector) {
        return System.Linq.Enumerable.GroupBy(source, keySelector);
    }
";

    private static readonly string maxFunction = @"
    public static int max<TSource>(IEnumerable<TSource> source, System.Func<TSource, int> selector) {
        return System.Linq.Enumerable.Max(source, selector);
    }
";

    private static readonly string countFunction = @"
    public static int count<TSource>(IEnumerable<TSource> source) {
        return System.Linq.Enumerable.Count(source);
    }
";

    private static readonly string asListFunction = @"
    public static IList<TSource> asList<TSource>(IEnumerable<TSource> source) {
        return System.Linq.Enumerable.ToList(source);
    }
";

    private static readonly string printSystemCall = @"
    public static void print(string s) {
        System.Console.Write(s);
    }
";

    private static readonly string printLineSystemCall = @"
    public static void printLine(string s) {
        System.Console.WriteLine(s);
    }
";

    private static readonly string inputSystemCall = @"
    public static string input(string s) {
        System.Console.Write(s);
        return System.Console.ReadLine();
    }
";

    public static readonly string AllLibraryFunctions = @$"
public static partial class GlobalConstants {{
{assertFunction}
{containsFunction}
{indexOfFunction}
{rangeFunction}
{reduceFunction}
{reduceFunction1}
{filterFunction}
{groupByFunction}
{maxFunction}
{countFunction}
{mapFunction}
{asListFunction}
{printSystemCall}
{printLineSystemCall}
{inputSystemCall}
}}".Trim();
}