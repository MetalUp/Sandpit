namespace SandpitCompiler.Model.Model;

public class IndexedValueModel : IModel {
    public IndexedValueModel(IModel expr, IModel index, ITypeModel type) {
        Expr = expr;
        Index = index;
        Type = type;
    }

    public IModel Expr { get; }
    public IModel Index { get; }
    public ITypeModel Type { get; }

    public override string ToString() => Type.IsTuple ? $"{Expr}.{ToTupleItem(Index)}" : $"{Expr}[{Index}]".Trim();
    public bool HasMain => false;

    private string ToTupleItem(IModel index) {
        if (!int.TryParse(index.ToString(), out var i)) {
            throw new Exception($"Unsupported tuple index {index}");
        }

        return $"Item{i + 1}";
    }
}