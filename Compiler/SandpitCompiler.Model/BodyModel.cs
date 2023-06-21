namespace SandpitCompiler.Model;

public class BodyModel : IModel {
    public BodyModel(IEnumerable<IModel> stats) => Stats = stats;

    private IEnumerable<IModel> Stats { get; }

    public override string ToString() =>
        $@"
          {Stats.AsLineSeparatedString()}
        ".Trim();

    public bool HasMain => false;
}