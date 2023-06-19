namespace SandpitCompiler.Model;

public class ProcModel : IModel {
    public ProcModel(string id, IEnumerable<IModel> parms, IEnumerable<IModel> vars) {
        ID = id;
        Parms = parms;
        Vars = vars;
    }

    private string ID { get; }
    private IEnumerable<IModel> Parms { get; }

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static void {ID}({Parms.AsCommaSeparatedString()}) {{
          {Vars.AsLineSeparatedString()}
        }}".Trim();

    public bool HasMain => false;
}