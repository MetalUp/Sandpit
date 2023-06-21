namespace SandpitCompiler.Model;

public class WhileModel : IModel {
    private IModel Expr { get; }
    private IModel Body { get; }

    public WhileModel(IModel expr, IModel body) {
        Expr = expr;
        Body = body;
       
    }

    public override string ToString() =>
        $@"
          while ({Expr}) {{
            {Body}
          }}
        ".Trim();

    public bool HasMain => false;
}