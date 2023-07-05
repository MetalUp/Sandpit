namespace SandpitCompiler.Model.Model;

public class IndexedValueModel : IModel {
    public IndexedValueModel(IModel expr, IModel index) {
        Expr = expr;
        Index = index;
    }

    public IModel Expr { get; }
    public IModel Index { get; }

    public override string ToString() => $"{Expr}[{Index}]".Trim();
    public bool HasMain => false;
}