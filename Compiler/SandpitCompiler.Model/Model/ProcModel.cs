namespace SandpitCompiler.Model.Model;

public class ProcModel : IModel {
    public ProcModel(string id, IEnumerable<IModel> parms, IEnumerable<IModel> stats) {
        ID = id;
        Parms = parms;
        Stats = stats;
    }

    private string ID { get; }
    private IEnumerable<IModel> Parms { get; }
    private IEnumerable<IModel> Stats { get; }

    public override string ToString() =>
        $@"public static void {ID}({Parms.AsCommaSeparatedString()}) {{
          {Stats.AsLineSeparatedString()}
        }}".Trim();

    public bool HasMain => false;
}