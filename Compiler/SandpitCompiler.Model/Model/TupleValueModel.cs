namespace SandpitCompiler.Model.Model;

public class TupleValueModel : IModel {
    public TupleValueModel(IModel[] vals) => Vals = vals;

    private IModel[] Vals { get; }

    public bool HasMain => false;
    public override string ToString() => $"({Vals.AsCommaSeparatedString()})";
}