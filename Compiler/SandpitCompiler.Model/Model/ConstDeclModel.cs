namespace SandpitCompiler.Model.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(IModel id, IModel value, ITypeModel type) {
        Id = id;
        Value = value;
        Type = type;
    }

    private IModel Id { get; }
    private IModel Value { get; }
    private ITypeModel Type { get; }

    public override string ToString() => $"public {Type.Prefix} {Type} {Id} = {Value};".Trim();
    public bool HasMain => false;
}