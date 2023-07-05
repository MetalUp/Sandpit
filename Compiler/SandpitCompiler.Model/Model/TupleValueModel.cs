namespace SandpitCompiler.Model.Model;

public class TupleValueModel : IModel {
    public TupleValueModel(IModel[] vals) => Vals = vals;

    public IModel[] Vals { get; }

    public bool HasMain => false;
    public override string ToString() => $"({Vals.AsCommaSeparatedString()})";
}