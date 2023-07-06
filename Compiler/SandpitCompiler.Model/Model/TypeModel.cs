namespace SandpitCompiler.Model.Model;

public class TypeModel : IModel {
    public TypeModel(string type) => Type = type;

    public string Type { get; }
    public bool HasMain { get; }

    public override string ToString() => $"const {Type}";
}