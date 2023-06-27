namespace SandpitCompiler.Model;

public class ProcStatModel : IModel {
    public string ID { get; }
    public IModel[] Parameters { get; }

    public ProcStatModel(string id, IModel[] parameters) {
        ID = id;
        Parameters = parameters;
    }

    public override string ToString() =>
        $@"
        {ID}({Parameters.AsCommaSeparatedString()});
        ".Trim();

    public bool HasMain => false;
}