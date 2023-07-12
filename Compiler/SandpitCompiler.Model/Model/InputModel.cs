namespace SandpitCompiler.Model.Model;

public class InputModel : IModel {
    private readonly IModel id;
    private readonly IModel expr;
    private readonly bool line;

    public InputModel(IModel id, IModel expr, bool line) {
        this.id = id;
        this.expr = expr;
        this.line = line;
    }

    public bool HasMain { get; }

    public override string ToString() => @$"
System.Console.WriteLine({expr});
{id} = System.Console.ReadLine();";
}