namespace SandpitCompiler.Model;

public interface IModel {
    public string ToString();

    public bool HasMain { get; }
}