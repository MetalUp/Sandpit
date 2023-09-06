namespace SandpitCompiler.AST.Symbols;

public class TupleType : IHasElementsSymbolType {
    public TupleType(ISymbolType[] elementTypes) => ElementTypes = elementTypes;

    public ISymbolType[] ElementTypes { get; }

    public override string ToString() => $"({string.Join(',', ElementTypes.Select(et => et.ToString()))})";

    public override bool Equals(object? obj) {
        if (obj is TupleType tt) {
            if (ElementTypes.Length == tt.ElementTypes.Length) {
                return ElementTypes.Zip(tt.ElementTypes).All(t => t.First.Equals(t.Second));
            }
        }

        return false;
    }

    public override int GetHashCode() => ElementTypes.Aggregate(0, (s, et) => s + et.GetHashCode());

    public ISymbolType Clone() => new TupleType(ElementTypes.Select(t => t.Clone()).ToArray());
}