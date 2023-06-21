namespace SandpitCompiler.Model;

public class BinaryOperatorModel : IModel {
    public BinaryOperatorModel(IModel op, IModel lhs, IModel rhs) {
        Op = op;
        Lhs = lhs;
        Rhs = rhs;
    }

    private IModel Op { get; }
    private IModel Lhs { get; }
    private IModel Rhs { get; }

    public override string ToString() => $"{Lhs} {Op} {Rhs}".Trim();
    public bool HasMain => false;
}