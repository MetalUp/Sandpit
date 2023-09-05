namespace SandpitCompiler.Model.Model;

public class AssignmentModel : IModel {
    public AssignmentModel(IModel id, IModel expr) {
        Expr = expr;
        Id = id;
    }

    private IModel Expr { get; }
    private IModel Id { get; }

    public override string ToString() => $"{Id} = {Expr};".Trim();
    public bool HasMain => false;
}