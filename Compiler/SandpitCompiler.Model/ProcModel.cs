namespace SandpitCompiler.Model;

public class ProcModel : IModel {
    public ProcModel(string id, IEnumerable<IModel> parms, IModel body) {
        ID = id;
        Parms = parms;
        Body = body;
    }

    private string ID { get; }
    private IEnumerable<IModel> Parms { get; }
    public IModel Body { get; }

    public override string ToString() =>
        $@"public static void {ID}({Parms.AsCommaSeparatedString()}) {{
          {Body.ToString()}
        }}".Trim();

    public bool HasMain => false;
}