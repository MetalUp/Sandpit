namespace SandpitCompiler.Model;

public interface ITypeModel : IModel {
    public string Prefix { get; }
    bool IsTuple { get; }
}