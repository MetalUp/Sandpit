namespace SandpitCompiler.AST.Symbols;

public class TupleType : ISymbolType {
    public TupleType(ISymbolType[] elementTypes) => ElementTypes = elementTypes;

    public ISymbolType[] ElementTypes { get; }
}