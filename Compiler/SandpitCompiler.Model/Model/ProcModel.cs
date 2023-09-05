namespace SandpitCompiler.Model.Model;

public class ProcModel : IModel {
    public ProcModel(IModel id, IEnumerable<IModel> parms, IEnumerable<IModel> stats) {
        Id = id;
        Parms = parms;
        Stats = stats;
    }

    private IModel Id { get; }
    private IEnumerable<IModel> Parms { get; }
    private IEnumerable<IModel> Stats { get; }

    public override string ToString() =>
        $@"public static void {Id}({Parms.AsCommaSeparatedString()}) {{
          {Stats.AsLineSeparatedString()}
        }}".Trim();

    public bool HasMain => false;
}