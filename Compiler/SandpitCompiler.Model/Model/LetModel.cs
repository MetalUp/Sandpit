namespace SandpitCompiler.Model.Model;

public class LetModel : IModel {
    private readonly IModel property;

    public LetModel(IModel expr, IModel property) {
        this.property = property;
        Expr = expr;
    }

    public IModel Expr { get; }

    public bool HasMain => false;
    public override string ToString() => $"Help";
}