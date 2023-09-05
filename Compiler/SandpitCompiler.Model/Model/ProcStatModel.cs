namespace SandpitCompiler.Model.Model;

public class ProcStatModel : IModel {
    public ProcStatModel(IModel id, IModel[] parameters) {
        Id = id;
        Parameters = parameters;
    }

    private IModel Id { get; }
    private IModel[] Parameters { get; }

    public override string ToString() =>
        $@"
        {Id}({Parameters.AsCommaSeparatedString()});
        ".Trim();

    public bool HasMain => false;
}