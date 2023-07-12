namespace SandpitCompiler.Model.Model;

public class LambdaValueModel : IModel {
    public LambdaValueModel(IModel[] args, IModel expr) {
        Args = args;
        Expr = expr;
    }

    private IModel[] Args { get; }
    private IModel Expr { get; }

    public bool HasMain => false;
    public override string ToString() => $"({Args.AsCommaSeparatedString()}) => {Expr}";
}