namespace SandpitCompiler.Model;

public class FileModel : IModel {
    public FileModel(IEnumerable<IModel> constants, IModel? main) {
        Constants = constants;
        Main = main;
    }

    private IEnumerable<IModel> Constants { get; }
    private IModel? Main { get; }

    public override string ToString() =>
        $@"
using static GlobalConstants;

public static partial class GlobalConstants {{
    {ConstantsAsString()}
}}

{Main?.ToString() ?? ""}
";

    public bool HasMain => Main is not null;

    private string ConstantsAsString() => string.Join('\n', Constants.Select(v => v.ToString()));
}