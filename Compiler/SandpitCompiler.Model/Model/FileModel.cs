namespace SandpitCompiler.Model.Model;

public class FileModel : IModel {
    private readonly string assertFunction = @"
public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
";

    private readonly IDictionary<ModelFlags, bool> flags;

    private readonly string printFunction = @"
public static void print(string s) { System.Console.WriteLine(s); }
";

    private readonly string containsFunction = @"
public static bool contains<T>(IEnumerable<T> arr, T item) { return System.Linq.Enumerable.Contains(arr, item); }
";

    // TODO do we need this structure - or just globals and main ?
    public FileModel(IDictionary<ModelFlags, bool> flags, IEnumerable<IModel> constants, IEnumerable<IModel> procedures, IEnumerable<IModel> functions, IModel? main) {
        this.flags = flags;
        Constants = constants;
        Procedures = procedures;
        Functions = functions;
        Main = main;
    }

    private IEnumerable<IModel> Constants { get; }
    private IEnumerable<IModel> Procedures { get; }
    private IEnumerable<IModel> Functions { get; }
    private IModel? Main { get; }

    public override string ToString() =>
        $@"
using System.Collections.Generic;
using System.Collections.Immutable;
using static GlobalConstants;

public static partial class GlobalConstants {{
{printFunction}
{assertFunction}
{containsFunction}
{Constants.AsLineSeparatedString(2)}
{Procedures.AsLineSeparatedString(2)}
{Functions.AsLineSeparatedString(2)}
}}
{Main?.ToString() ?? ""}".Trim();

    public bool HasMain => Main is not null;
}