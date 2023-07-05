namespace SandpitCompiler.Model.Model;

public class TernaryValueModel : IModel {
    public TernaryValueModel(IModel condition, IModel lhs, IModel rhs) {
        Condition = condition;
        Lhs = lhs;
        Rhs = rhs;
    }

    private IModel Condition { get; }
    private IModel Lhs { get; }
    private IModel Rhs { get; }

    public override string ToString() => $"{Condition} ? {Lhs} : {Rhs}".Trim();
    public bool HasMain => false;
}