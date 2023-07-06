namespace SandpitCompiler.Model.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(IModel id, IModel value, IModel type) {
        ID = id;
        Value = value;
        Type = type;
    }

    private IModel ID { get; }
    private IModel Value { get; }
    public IModel Type { get; }

    public override string ToString() => $"public {Type} {ID} = {Value};".Trim();
    public bool HasMain => false;
}