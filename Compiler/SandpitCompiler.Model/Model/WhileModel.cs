namespace SandpitCompiler.Model.Model;

public class WhileModel : IModel {
    public WhileModel(IModel expr, IEnumerable<IModel> stats) {
        Expr = expr;
        Stats = stats;
    }

    private IModel Expr { get; }
    private IEnumerable<IModel> Stats { get; }

    public override string ToString() =>
        $@"
          while ({Expr}) {{
            {Stats.AsLineSeparatedString()}
          }}
        ".Trim();

    public bool HasMain => false;
}