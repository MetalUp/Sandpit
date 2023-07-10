namespace SandpitCompiler.Model.Model;

public class RangeValueModel : IModel {
    private readonly IModel from;

    private readonly string prefix;
    private readonly string suffix;
    private readonly string to;

    public RangeValueModel(bool prefix, IModel from, IModel? to) {
        this.prefix = prefix ? ".." : "";
        suffix = prefix ? "" : "..";
        this.from = from;
        this.to = to is null ? "" : $"({to})";
    }

    public override string ToString() => $"{prefix}({from}){suffix}{to}".Trim();
    public bool HasMain => false;
}