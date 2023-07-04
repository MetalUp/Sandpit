namespace SandpitCompiler.Model.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(string id, ValueModel value) {
        ID = id;
        Value = value;
    }

    private string ID { get; }
    private ValueModel Value { get; }

    public bool IsList => Value.IsList;

    public override string ToString() => $"public {Value.Prefix} {Value.Type} {ID} = {Value.Val};".Trim();
    public bool HasMain => false;
}