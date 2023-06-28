namespace SandpitCompiler.Model;

public class MainModel : IModel {
    public MainModel(IModel body) => Body = body;

    private IModel Body { get; }

    public override string ToString() =>
        $@"public static class Program {{
    private static void Main(string[] args) {{
      {Body}
    }}
}}".Trim();

    public bool HasMain => false;
}