namespace SandpitCompiler.Model;

public class ConstDeclModel : IModel {
    public ConstDeclModel(string id, string @int) {
        Int = @int;
        ID = id;
    }

    private string Int { get; }
    private string ID { get; }

    public override string ToString() => $"public const int {ID} = {Int};".Trim();
    public bool HasMain => false;
}