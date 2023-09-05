namespace SandpitCompiler.Model.Model;

public class FuncModel : IModel {
    public FuncModel(IModel id, IModel type, IEnumerable<IModel> parms, IEnumerable<IModel> stats, IModel ret) {
        Id = id;
        Type = type;
        Parms = parms;
        Stats = stats;
        Ret = ret;
    }

    private IModel Id { get; }
    private IModel Type { get; }
    private IEnumerable<IModel> Parms { get; }
    private IEnumerable<IModel> Stats { get; }
    private IModel Ret { get; }

    public override string ToString() =>
        $@"public static {Type} {Id}({Parms.AsCommaSeparatedString()}) {{
          {Stats.AsLineSeparatedString()}
          return {Ret.ToString()};
        }}".Trim();

    public bool HasMain => false;
}