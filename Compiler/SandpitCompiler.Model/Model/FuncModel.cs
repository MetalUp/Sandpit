namespace SandpitCompiler.Model.Model;

public class FuncModel : IModel {
    public FuncModel(string id, string type, IEnumerable<IModel> parms, IEnumerable<IModel> stats, IModel ret) {
        ID = id;
        Type = type;
        Parms = parms;
        Stats = stats;
        Ret = ret;
    }

    private string ID { get; }
    private string Type { get; }
    private IEnumerable<IModel> Parms { get; }
    public IEnumerable<IModel> Stats { get; }
    public IModel Ret { get; }

    public override string ToString() =>
        $@"public static {ModelHelpers.TypeLookup(Type)} {ID}({Parms.AsCommaSeparatedString()}) {{
          {Stats.AsLineSeparatedString()}
          return {Ret.ToString()};
        }}".Trim();

    public bool HasMain => false;
}