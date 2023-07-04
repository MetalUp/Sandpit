namespace SandpitCompiler.Model.Model;

public class ValueModel : IModel {
    public ValueModel(string val, string type) {
        Val = val;
        Type = type;
        Prefix = "const";
    }

    public ValueModel(string[] val, string retType,  string type) {
        Val = $"new {type} {{ {string.Join(',', val)} }}.ToImmutableList()";
        Type = retType;
        Prefix = "static readonly";
    }

    public string Val { get; }
    public string Type { get; }
    public string Prefix { get; }

    public bool HasMain => false;
    public override string ToString() => Val;
}