namespace SandpitCompiler.Model.Model;

public class ParamModel : IModel {
    public ParamModel(string id, string type) {
        Type = type;
        ID = id;
    }

    private string Type { get; }
    private string ID { get; }

    public override string ToString() => $"{Type} {ID}".Trim();
    public bool HasMain => false;
}