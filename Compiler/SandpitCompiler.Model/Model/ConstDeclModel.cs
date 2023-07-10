namespace SandpitCompiler.Model.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(string id, IModel value, ITypeModel type) {
        ID = id;
        Value = value;
        Type = type;
    }

    private string ID { get; }
    private IModel Value { get; }
    private ITypeModel Type { get; }

    public override string ToString() => $"public {Type.Prefix} {Type} {ID} = {Value};".Trim();
    public bool HasMain => false;
}