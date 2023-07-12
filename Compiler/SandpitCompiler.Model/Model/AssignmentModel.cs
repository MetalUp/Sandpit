namespace SandpitCompiler.Model.Model;

public class AssignmentModel : IModel {
    public AssignmentModel(string id, IModel expr) {
        Expr = expr;
        ID = id;
    }

    private IModel Expr { get; }
    private string ID { get; }

    public override string ToString() => $"{ID} = {Expr};".Trim();
    public bool HasMain => false;
}