namespace SandpitCompiler.Model.Model;

public class ValueModel : IModel {
    public ValueModel(string val) => Val = val;

    public ValueModel(string[] val, TypeModel type) => Val = $"new {type.ImplType} {{ {string.Join(", ", val)} }}.ToImmutableList()";

    public ValueModel(IModel[] val) => Val = $"({string.Join(", ", val.Select(v => v.ToString()).ToArray())})";

    public string Val { get; }

    public bool HasMain => false;
    public override string ToString() => Val;
}