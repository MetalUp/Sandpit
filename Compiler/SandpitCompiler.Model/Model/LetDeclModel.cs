namespace SandpitCompiler.Model.Model;

public class LetDeclModel : IModel {
    private readonly IModel returnExpression;
    private readonly ITypeModel type;

    public LetDeclModel(IModel[] lets, IModel returnExpression, ITypeModel type) {
        Lets = lets;

        this.returnExpression = returnExpression;
        this.type = type;
    }

    private IModel[] Lets { get; }

    public override string ToString() => $@"new System.Func<{type}>(() => {{
       {Lets.Aggregate("", (a, t) => $@"{a}
var {t}")}
       return {returnExpression};
    }})()".Trim();

    public bool HasMain => false;
}