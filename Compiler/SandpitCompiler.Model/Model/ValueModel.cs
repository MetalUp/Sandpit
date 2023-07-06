namespace SandpitCompiler.Model.Model;

public class ValueModel : IModel {
    

    public ValueModel(IModel val, IModel type) {
        Val = val;
        Type = type;
        Prefix = "const";
    }

    public ValueModel(IModel[] vals, IModel retType, IModel type) {
        Vals = vals;

        Type = retType;
        Prefix = "static readonly";
    }

    public IModel? Val { get; }

    public IModel[]? Vals { get; }
    public IModel Type { get; }
    public string Prefix { get; }

    public bool HasMain => false;
    public override string ToString() => Val is not null ? Val.ToString() : Vals.AsCommaSeparatedString();
}