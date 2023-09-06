namespace SandpitCompiler.AST.Symbols;

public class ListType : IterableType {
    public ListType(ISymbolType elementType) : base(elementType) { }

    public override string ToString() => $"[{ElementType}]";

    public override ISymbolType Clone() => new ListType(ElementType.Clone());
}