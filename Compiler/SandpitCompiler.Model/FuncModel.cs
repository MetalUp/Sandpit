namespace SandpitCompiler.Model;

public class FuncModel : IModel {
    public FuncModel(string id, string type, IEnumerable<IModel> parms, IEnumerable<IModel> vars) {
        ID = id;
        Type = type;
        Parms = parms;
        Vars = vars;
    }

    private string ID { get; }
    public string Type { get; }
    public IEnumerable<IModel> Parms { get; }

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static {ModelHelpers.TypeLookup[Type]} {ID}({ParmsAsString()}) {{
          {VarsAsString()}
          return 1; // placeholder  
        }}".Trim();

    public bool HasMain => false;

    private string VarsAsString() => string.Join("\r\n  ", Vars.Select(v => v.ToString())).Trim();

    private string ParmsAsString() => string.Join(", ", Parms.Select(v => v.ToString())).Trim();
}