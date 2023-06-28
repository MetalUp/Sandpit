namespace SandpitCompiler.Model;

public class WhileModel : IModel {
    public WhileModel(IModel expr, IModel body) {
        Expr = expr;
        Body = body;
    }

    private IModel Expr { get; }
    private IModel Body { get; }

    public override string ToString() =>
        $@"
          while ({Expr}) {{
            {Body}
          }}
        ".Trim();

    public bool HasMain => false;
}