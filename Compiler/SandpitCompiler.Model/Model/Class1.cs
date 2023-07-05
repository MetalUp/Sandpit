using System.Collections.Generic;
using System.Collections.Immutable;
using static GlobalConstants;

public static partial class GlobalConstants {
    public static void print(string s) {
        System.Console.WriteLine(s);
    }

    public static void assert(bool b) {
        if (b) throw new System.Exception("Assert Failed");
    }

    public static bool contains<T>(IEnumerable<T> arr, T item) {
        return System.Linq.Enumerable.Contains(arr, item);
    }

    public static bool isGreen(string attempt, string target, int n) {
        return target[n] == attempt[n];
    }

    public static string setChar(string word, int n, char newChar) {
        return word[..(n)] + newChar + word[(n + 1)..];
    }

    public static string setAttemptIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(attempt, n, '*') : attempt;
    }

    public static string setTargetIfGreen(string attempt, string target, int n) {
        return isGreen(attempt, target, n) ? setChar(attempt, n, '.') : attempt;
    }

    public static bool isYellow(string attempt, string target, int n) {
        return contains(target, attempt[n]);
    }
}
