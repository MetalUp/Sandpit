namespace SandpitCompiler.Model;

public class FuncModel : IModel {
    public FuncModel(string id, string type, IEnumerable<IModel> parms, IEnumerable<IModel> vars) {
        ID = id;
        Type = type;
        Parms = parms;
        Vars = vars;
    }

    private string ID { get; }
    private string Type { get; }
    private IEnumerable<IModel> Parms { get; }
    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static {ModelHelpers.TypeLookup[Type]} {ID}({Parms.AsCommaSeparatedString()}) {{
          {Vars.AsLineSeparatedString()}
          return 1; // placeholder  
        }}".Trim();

    public bool HasMain => false;
}