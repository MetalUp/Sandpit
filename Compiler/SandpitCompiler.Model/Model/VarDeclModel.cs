namespace SandpitCompiler.Model.Model;

public class VarDeclModel : IModel {
    public VarDeclModel(IModel id, IModel expr) {
        Expr = expr;
        Id = id;
    }

    private IModel Expr { get; }
    private IModel Id { get; }

    public override string ToString() => $"var {Id} = {Expr};".Trim();
    public bool HasMain => false;
}