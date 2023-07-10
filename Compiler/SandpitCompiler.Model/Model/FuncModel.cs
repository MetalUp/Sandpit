namespace SandpitCompiler.Model.Model;

public class FuncModel : IModel {
    public FuncModel(string id, IModel type, IEnumerable<IModel> parms, IEnumerable<IModel> stats, IModel ret) {
        ID = id;
        Type = type;
        Parms = parms;
        Stats = stats;
        Ret = ret;
    }

    private string ID { get; }
    private IModel Type { get; }
    private IEnumerable<IModel> Parms { get; }
    public IEnumerable<IModel> Stats { get; }
    public IModel Ret { get; }

    public override string ToString() =>
        $@"public static {Type} {ID}({Parms.AsCommaSeparatedString()}) {{
          {Stats.AsLineSeparatedString()}
          return {Ret.ToString()};
        }}".Trim();

    public bool HasMain => false;
}