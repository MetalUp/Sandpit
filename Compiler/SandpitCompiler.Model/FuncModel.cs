namespace SandpitCompiler.Model;

public class FuncModel : IModel {
    public FuncModel(string id, string type, string @return, IEnumerable<IModel> parms, IEnumerable<IModel> vars) {
        ID = id;
        Type = type;
        Return = @return;
        Parms = parms;
        Vars = vars;
    }

    private string ID { get; }
    private string Type { get; }
    public string Return { get; }
    private IEnumerable<IModel> Parms { get; }
    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static {ModelHelpers.TypeLookup[Type]} {ID}({Parms.AsCommaSeparatedString()}) {{
          {Vars.AsLineSeparatedString()}
          return {Return};
        }}".Trim();

    public bool HasMain => false;
}