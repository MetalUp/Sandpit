namespace SandpitCompiler.Model.Model;

public class AssignmentModel : IModel {
    public AssignmentModel(IModel id, IModel expr) {
        Expr = expr;
        ID = id;
    }

    private IModel Expr { get; }
    private IModel ID { get; }

    public override string ToString() => $"{ID} = {Expr};".Trim();
    public bool HasMain => false;
}