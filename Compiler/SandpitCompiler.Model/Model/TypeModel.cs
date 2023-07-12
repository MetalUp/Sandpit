using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Model.Model;

public class TypeModel : ITypeModel {
    public TypeModel(ISymbolType? symbolType, IScope scope) {
        SymbolType = symbolType;
        Scope = scope;
    }

    private ISymbolType? SymbolType { get; }
    private IScope Scope { get; }

    public string ImplType => ModelHelpers.ImplTypeLookup(SymbolType, Scope);

    public bool HasMain { get; }

    public override string ToString() => ModelHelpers.TypeLookup(SymbolType, Scope);

    public string Prefix => ModelHelpers.PrefixLookup(SymbolType);

    public bool IsTuple => ModelHelpers.IsTuple(SymbolType, Scope);
}