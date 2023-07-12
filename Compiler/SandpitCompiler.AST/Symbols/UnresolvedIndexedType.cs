using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Symbols;

public class UnresolvedIndexedType : IUnresolvedType {
    private readonly IExpression index;

    public UnresolvedIndexedType(ISymbolType symbolType, IExpression index) {
        this.index = index;
        SymbolType = symbolType;
    }

    private ISymbolType SymbolType { get; }

    public ISymbolType Resolve(IScope scope) {
        var st = SymbolType is IUnresolvedType ut ? ut.Resolve(scope) : SymbolType;

        if (st is TupleType tt) {
            if (index is ScalarValueNode svn) {
                var i = int.Parse(svn.Text);
                return tt.ElementTypes[i];
            }

            throw new NotImplementedException();
        }

        if (st is ListType lt) {
            return lt.ElementType;
        }

        if (st is IterableType it) {
            return it.ElementType;
        }

        throw new NotImplementedException();
    }
}