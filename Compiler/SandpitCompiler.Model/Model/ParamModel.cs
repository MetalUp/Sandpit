namespace SandpitCompiler.Model.Model;

public class ParamModel : IModel {
    public ParamModel(IModel id, string type) {
        Type = type;
        Id = id;
    }

    private string Type { get; }
    private IModel Id { get; }

    public override string ToString() => $"{Type} {Id}".Trim();
    public bool HasMain => false;
}