namespace SandpitCompiler.AST.Symbols;

public class IterableType : ISymbolType {
    public IterableType(ISymbolType elementType) => ElementType = elementType;

    public ISymbolType ElementType { get; }
}