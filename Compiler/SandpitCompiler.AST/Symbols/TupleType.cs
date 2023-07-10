using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Symbols;

public class TupleType : ISymbolType {
    public TupleType(ISymbolType[] elementTypes) => ElementTypes = elementTypes;

    public ISymbolType[] ElementTypes { get; }
}