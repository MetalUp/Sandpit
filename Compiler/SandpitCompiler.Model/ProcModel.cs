namespace SandpitCompiler.Model;

public class ProcModel : IModel {
    public ProcModel(string id, IEnumerable<IModel> vars) {
        ID = id;
        Vars = vars;
    }

    private string ID { get; }

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static void {ID}() {{
          {VarsAsString()}
        }}".Trim();

    public bool HasMain => false;

    private string VarsAsString() => string.Join("\r\n  ", Vars.Select(v => v.ToString())).Trim();
}