namespace SandpitCompiler.Model;

public class VarDeclModel : IModel {
    public VarDeclModel(string id, string expr) {
        Expr = expr;
        ID = id;
    }

    private string Expr { get; }
    private string ID { get; }

    public override string ToString() => $"var {ID} = {Expr};".Trim();
    public bool HasMain => false;
}