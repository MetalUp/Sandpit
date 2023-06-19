namespace SandpitCompiler.Model;

public class FileModel : IModel {

    // TODO do we need this structure - or just globals and main ?
    public FileModel(IEnumerable<IModel> constants, IEnumerable<IModel> procedures,  IEnumerable<IModel> functions, IModel? main) {
        Constants = constants;
        Procedures = procedures;
        Functions = functions;
        Main = main;
    }

    private IEnumerable<IModel> Constants { get; }

    private IEnumerable<IModel> Procedures { get; }
    public IEnumerable<IModel> Functions { get; }
    private IModel? Main { get; }

    public override string ToString() =>
        $@"
using static GlobalConstants;

public static partial class GlobalConstants {{
  {ConstantsAsString()}
  {ProceduresAsString()}
  {FunctionsAsString()}
}}
{Main?.ToString() ?? ""}".Trim();

    public bool HasMain => Main is not null;

    private string ConstantsAsString() => string.Join("\r\n  ", Constants.Select(v => v.ToString())).Trim();

    private string ProceduresAsString() => string.Join("\r\n  ", Procedures.Select(v => v.ToString())).Trim();

    private string FunctionsAsString() => string.Join("\r\n  ", Functions.Select(v => v.ToString())).Trim();
}