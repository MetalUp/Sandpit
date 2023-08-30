// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Sandpit.Compiler.Lib;

public class StandardLib {
    public static void assert(bool b) {
        if (!b) {
            throw new Exception("Assert Failed");
        }
    }

    public static bool contains<T>(IEnumerable<T> arr, T item) => arr.Contains(item);

    // TODO do we need lazy impl
    public static int indexOf<T>(IEnumerable<T> arr, T item) => arr.ToList().IndexOf(item);

    public static IEnumerable<int> range(int i) => Enumerable.Range(0, i);

    public static TAccumulate reduce<TSource, TAccumulate>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) => source.Aggregate(seed, func);

    public static TSource reduce<TSource>(IEnumerable<TSource> source, Func<TSource, TSource, TSource> func) => source.Aggregate(func);

    public static IEnumerable<TSource> filter<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate) => source.Where(predicate);

    public static IEnumerable<TResult> map<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> predicate) => source.Select(predicate);

    public static IEnumerable<IEnumerable<TSource>> groupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector) => source.GroupBy(keySelector);

    public static int max<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector) => source.Max(selector);

    public static int count<TSource>(IEnumerable<TSource> source) => source.Count();

    public static IList<TSource> asList<TSource>(IEnumerable<TSource> source) => source.ToList();

    public static void print(string s) => Console.Write(s);

    public static void printLine(string s) => Console.WriteLine(s);

    public static string input(string s) {
        Console.Write(s);
        return Console.ReadLine() ?? "";
    }
}