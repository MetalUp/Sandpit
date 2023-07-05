namespace SandpitCompiler.Model.Model;

public class FuncCallModel : IModel {
    public FuncCallModel(string id, IModel[] parameters) {
        ID = id;
        Parameters = parameters;
    }

    public string ID { get; }
    public IModel[] Parameters { get; }

    public override string ToString() =>
        $@"
        {ID}({Parameters.AsCommaSeparatedString()})
        ".Trim();

    public bool HasMain => false;
}