namespace SandpitCompiler.AST.Symbols;

public class FuncType : IHasElementsSymbolType {

    public FuncType(ISymbolType[] elementTypes) => ElementTypes = elementTypes;

    public ISymbolType[] ElementTypes { get; }

    public override string ToString() => $"lamba<{string.Join(',', ElementTypes.Select(et => et.ToString()))}>";

    public override bool Equals(object? obj) {
        if (obj is FuncType tt) {
            if (ElementTypes.Length == tt.ElementTypes.Length) {
                return ElementTypes.Zip(tt.ElementTypes).All(t => t.First.Equals(t.Second));
            }
        }

        return false;
    }

    public override int GetHashCode() => ElementTypes.Aggregate(0, (s, et) => s + et.GetHashCode());

    public ISymbolType Clone() => new FuncType(ElementTypes.Select(t => t.Clone()).ToArray());
}