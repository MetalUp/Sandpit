namespace SandpitCompiler.Model;

public class FuncModel : IModel {
    public FuncModel(string id, string type, IEnumerable<IModel> parms, IModel body) {
        ID = id;
        Type = type;
        Parms = parms;
        Body = body;
    }

    private string ID { get; }
    private string Type { get; }
    private IEnumerable<IModel> Parms { get; }
    private IModel Body { get; }

    public override string ToString() =>
        $@"public static {ModelHelpers.TypeLookup(Type)} {ID}({Parms.AsCommaSeparatedString()}) {{
          {Body}
        }}".Trim();

    public bool HasMain => false;
}