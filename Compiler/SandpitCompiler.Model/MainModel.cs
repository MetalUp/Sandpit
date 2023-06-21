namespace SandpitCompiler.Model;

public class MainModel : IModel {
    private IModel Body { get; }

    public MainModel(IModel body) {
        Body = body;
    }

    public override string ToString() =>
        $@"public static class Program {{
    private static void Main(string[] args) {{
      {Body}
    }}
}}".Trim();

    public bool HasMain => false;
}