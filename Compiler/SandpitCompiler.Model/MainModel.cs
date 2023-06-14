namespace SandpitCompiler.Model;

public class MainModel : IModel {
    public MainModel(IEnumerable<IModel> vars) => Vars = vars;

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static class Program {{
    private static void Main(string[] args) {{
      {VarsAsString()}
        
    }}
}}".Trim();

    public bool HasMain => false;

    private string VarsAsString() => string.Join("\r\n      ", Vars.Select(v => v.ToString())).Trim();
}