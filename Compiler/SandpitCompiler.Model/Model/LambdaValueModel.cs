namespace SandpitCompiler.Model.Model;

public class LambdaValueModel : IModel {
    public LambdaValueModel(IModel[] args, IModel expr) {
        Args = args;
        Expr = expr;
    }

    public IModel[] Args { get; }
    public IModel Expr { get; }

    public bool HasMain => false;
    public override string ToString() => $"({Args.AsCommaSeparatedString()}) => {Expr}";
}