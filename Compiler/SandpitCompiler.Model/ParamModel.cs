namespace SandpitCompiler.Model;

public class ParamModel : IModel {
    public ParamModel(string id, string type) {
        Type = type;
        ID = id;
    }

    private string Type { get; }
    private string ID { get; }

    public override string ToString() => $"{ModelHelpers.TypeLookup[Type]} {ID}".Trim();
    public bool HasMain => false;
}