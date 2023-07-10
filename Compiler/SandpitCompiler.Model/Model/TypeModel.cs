using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Model.Model;

public class TypeModel : ITypeModel {
    public TypeModel(ISymbolType? symbolType) => SymbolType = symbolType;

    public ISymbolType? SymbolType { get; }

    public bool HasMain { get; }

    public override string ToString() => ModelHelpers.TypeLookup(SymbolType);

    public string Prefix => ModelHelpers.PrefixLookup(SymbolType);

    public string ImplType => ModelHelpers.ImplTypeLookup(SymbolType);
}


