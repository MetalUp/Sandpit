namespace SandpitCompiler.Model.Model;

public class ValueModel : IModel {
    public ValueModel(string val) => Val = val;

    public ValueModel(string[] val, TypeModel type) => Val = $"new {type.ImplType} {{ {string.Join(", ", val)} }}.ToImmutableList()";

    public string Val { get; }

    public bool HasMain => false;
    public override string ToString() => Val;
}