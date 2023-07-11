namespace SandpitCompiler.AST.Symbols;

public class ListType : ISymbolType {
    public ListType(ISymbolType elementType) => ElementType = elementType;

    public ISymbolType ElementType { get; }
}