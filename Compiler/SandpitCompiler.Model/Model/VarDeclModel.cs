namespace SandpitCompiler.Model.Model;

public class VarDeclModel : IModel {
    public VarDeclModel(string id, IModel expr) {
        Expr = expr;
        ID = id;
    }

    private IModel Expr { get; }
    private string ID { get; }

    public override string ToString() => $"var {ID} = {Expr};".Trim();
    public bool HasMain => false;
}