namespace SandpitCompiler.Model;

public class ProcStatModel : IModel {
    public ProcStatModel(string id, IModel[] parameters) {
        ID = id;
        Parameters = parameters;
    }

    public string ID { get; }
    public IModel[] Parameters { get; }

    public override string ToString() =>
        $@"
        {ID}({Parameters.AsCommaSeparatedString()});
        ".Trim();

    public bool HasMain => false;
}