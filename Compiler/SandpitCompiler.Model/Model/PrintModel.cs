namespace SandpitCompiler.Model.Model;

public class PrintModel : IModel {
    private readonly IModel expr;
    private readonly bool line;

    public PrintModel(IModel expr, bool line) {
        this.expr = expr;
        this.line = line;
    }

    public bool HasMain { get; }

    public override string ToString() => $"System.Console.{(line ? "WriteLine" : "Write")}({expr});";
}