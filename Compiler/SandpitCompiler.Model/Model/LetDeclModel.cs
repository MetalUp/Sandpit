namespace SandpitCompiler.Model.Model;

public class LetDeclModel : IModel {
    private readonly IModel returnExpression;
    private readonly ITypeModel type;

    public LetDeclModel((IModel id, IModel expr)[] lets, IModel returnExpression, ITypeModel type) {
        Lets = lets;

        this.returnExpression = returnExpression;
        this.type = type;
    }

    private (IModel id, IModel expr)[] Lets { get; }

    public override string ToString() => $@"new System.Func<{type}>(() => {{
       {Lets.Aggregate("", (a, t) => $@"{a}
var {t.id} = {t.expr};")}
       return {returnExpression};
    }})()".Trim();

    public bool HasMain => false;
}