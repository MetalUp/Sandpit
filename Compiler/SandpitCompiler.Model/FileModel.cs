namespace SandpitCompiler.Model;

public class FileModel : IModel {
    private string assertFunction = @"
public static void assert(bool b) { if (b) throw new System.Exception(""Assert Failed""); }
";

    private string printFunction = @"
public static void print(string s) { System.Console.WriteLine(s); }
";

    // TODO do we need this structure - or just globals and main ?
    public FileModel(IEnumerable<IModel> constants, IEnumerable<IModel> procedures, IEnumerable<IModel> functions, IModel? main) {
        Constants = constants;
        Procedures = procedures;
        Functions = functions;
        Main = main;
    }

    private IEnumerable<IModel> Constants { get; }
    private IEnumerable<IModel> Procedures { get; }
    private IEnumerable<IModel> Functions { get; }
    private IModel? Main { get; }

    private bool UsesCollections => Constants.Any(c => c is ConstDeclModel and { IsList: true });

    public override string ToString() =>
        $@"
{(UsesCollections ? "using System.Collections.Generic;" : "")}
{(UsesCollections ? "using System.Collections.Immutable;" : "")}
using static GlobalConstants;

public static partial class GlobalConstants {{
{Constants.AsLineSeparatedString(2)}
{Procedures.AsLineSeparatedString(2)}
{Functions.AsLineSeparatedString(2)}
}}
{Main?.ToString() ?? ""}".Trim();

    public bool HasMain => Main is not null;
}