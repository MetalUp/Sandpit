namespace SandpitCompiler.Model.Model;

public class LetDeclModel : IModel {
    private readonly IModel expr1;
    private readonly IModel expr2;
    private readonly ITypeModel type;

    public LetDeclModel(IModel id, IModel expr1, IModel expr2,  ITypeModel type) {
        this.expr1 = expr1;
        this.expr2 = expr2;
        this.type = type;
        ID = id;
    }

   
    private IModel ID { get; }

    public override string ToString() => $@"new System.Func<{type}>(() => {{
       var {ID} = {expr1};
       return {expr2};
    }})()".Trim();
    public bool HasMain => false;
}