namespace SandpitCompiler.Model;

public class MainModel : IModel {
    public MainModel(IEnumerable<IModel> vars) => Vars = vars;

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static class Program {{
    private static void Main(string[] args) {{
      {Vars.AsLineSeparatedString()}
        
    }}
}}".Trim();

    public bool HasMain => false;
}