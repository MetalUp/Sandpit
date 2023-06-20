namespace SandpitCompiler.Model;

public class FuncBodyModel : IModel {
    public FuncBodyModel(string @return, IEnumerable<IModel> lets) {
        Return = @return;
        Lets = lets;
    }

    private string Return { get; }
   
    private IEnumerable<IModel> Lets { get; }

    public override string ToString() =>
        $@"
          {Lets.AsLineSeparatedString()}
          return {Return};
        ".Trim();

    public bool HasMain => false;
}