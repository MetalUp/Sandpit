namespace SandpitCompiler.Model;

public class FileModel : IModel {
    public FileModel(IEnumerable<IModel> constants, IEnumerable<IModel> procedures, IModel? main) {
        Constants = constants;
        Procedures = procedures;
        Main = main;
    }

    private IEnumerable<IModel> Constants { get; }

    private IEnumerable<IModel> Procedures { get; }
    private IModel? Main { get; }

    public override string ToString() =>
        $@"
using static GlobalConstants;

public static partial class GlobalConstants {{
  {ConstantsAsString()}
  {ProceduresAsString()}
}}
{Main?.ToString() ?? ""}".Trim();

    public bool HasMain => Main is not null;

    private string ConstantsAsString() => string.Join("\r\n  ", Constants.Select(v => v.ToString())).Trim();

    private string ProceduresAsString() => string.Join("\r\n  ", Procedures.Select(v => v.ToString())).Trim();
}