namespace SandpitCompiler.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(string id, string val, string type) {
        Val = val;
        Type = type;
        ID = id;
    }

    private string Val { get; }
    public string Type { get; }
    private string ID { get; }

    public override string ToString() => $"public const {ModelHelpers.TypeLookup[Type]} {ID} = {Val};".Trim();
    public bool HasMain => false;
}