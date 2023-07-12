namespace SandpitCompiler.Model.Model;

public class ProcStatModel : IModel {
    public ProcStatModel(string id, IModel[] parameters) {
        ID = id;
        Parameters = parameters;
    }

    private string ID { get; }
    private IModel[] Parameters { get; }

    public override string ToString() =>
        $@"
        {ID}({Parameters.AsCommaSeparatedString()});
        ".Trim();

    public bool HasMain => false;
}