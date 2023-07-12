namespace SandpitCompiler.Model.Model;

public class IndexedValueModel : IModel {
    public IndexedValueModel(IModel expr, IModel index, ITypeModel type) {
        Expr = expr;
        Index = index;
        Type = type;
    }

    private IModel Expr { get; }
    private IModel Index { get; }
    private ITypeModel Type { get; }

    public override string ToString() => Type.IsTuple ? $"{Expr}.{ToTupleItem(Index)}" : $"{Expr}[{Index}]".Trim();
    public bool HasMain => false;

    private static string ToTupleItem(IModel index) {
        if (!int.TryParse(index.ToString(), out var i)) {
            throw new Exception($"Unsupported tuple index {index}");
        }

        return $"Item{i + 1}";
    }
}