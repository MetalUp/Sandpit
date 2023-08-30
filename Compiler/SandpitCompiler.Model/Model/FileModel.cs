namespace SandpitCompiler.Model.Model;

public class FileModel : IModel {
    private readonly IDictionary<ModelFlags, bool> flags;

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
using static Sandpit.Compiler.Lib.StandardLib;

public static partial class GlobalConstants {{
{Constants.AsLineSeparatedString(2)}
{Procedures.AsLineSeparatedString(2)}
{Functions.AsLineSeparatedString(2)}
}}
{Main?.ToString() ?? ""}".Trim();

    public bool HasMain => Main is not null;
}