namespace SandpitCompiler.Model.Model;

public class DereferenceModel : IModel {
    private readonly IModel property;

    public DereferenceModel(IModel expr, IModel property) {
        this.property = property;
        Expr = expr;
    }

    private IModel Expr { get; }

    public bool HasMain => false;
    public override string ToString() => $"{Expr}.{property}";
}