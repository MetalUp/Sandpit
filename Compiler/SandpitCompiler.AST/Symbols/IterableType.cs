namespace SandpitCompiler.AST.Symbols;

public class IterableType : IHasElementsSymbolType {
    public IterableType(ISymbolType elementType) => ElementTypes = new[] {elementType};

    public ISymbolType ElementType => ElementTypes[0];
    public ISymbolType[] ElementTypes { get; set; }

    public override string ToString() => $"Iterable of {ElementType}";
    public virtual ISymbolType Clone() => new IterableType(ElementType.Clone());

    public override bool Equals(object? obj) {
        if (obj?.GetType() == GetType() && obj is IterableType lt) {
            return ElementType.Equals(lt.ElementType);
        }

        return false;
    }

    public override int GetHashCode() => ElementType.GetHashCode();
}