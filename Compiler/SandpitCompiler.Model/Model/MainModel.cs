namespace SandpitCompiler.Model.Model;

public class MainModel : IModel {
    public MainModel(IEnumerable<IModel> stats) => Stats = stats;

    public IEnumerable<IModel> Stats { get; }

    public override string ToString() =>
        $@"public static class Program {{
    private static void Main(string[] args) {{
      {Stats.AsLineSeparatedString()}
    }}
}}".Trim();

    public bool HasMain => false;
}