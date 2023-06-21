namespace SandpitCompiler.Model;

public class ValueModel : IModel {
    public ValueModel(string val, string type) {
        Val = val;
        Type = ModelHelpers.TypeLookup(type);
        Prefix = "const";
        IsList = false;
    }

    public ValueModel(string[] val, string type) {
        Val = $"new List<{ModelHelpers.TypeLookup(type)}> {{ {string.Join(',', val)} }}.ToImmutableList()";
        Type = $"IList<{ModelHelpers.TypeLookup(type)}>";
        Prefix = "static readonly";
        IsList = true;
    }

    public bool IsList { get; }
    public string Val { get; }
    public string Type { get; }
    public string Prefix { get; }

    public bool HasMain => false;
    public override string ToString() => Val;
}