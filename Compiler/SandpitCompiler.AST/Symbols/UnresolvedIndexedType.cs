using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Symbols;

public class UnresolvedIndexedType : UnresolvedType, ISymbolType {
    private readonly IExpression index;

    public UnresolvedIndexedType(ISymbolType symbolType, IExpression index) : base("") {
        this.index = index;
        SymbolType = symbolType;
    }

    public ISymbolType SymbolType { get; }

    public override ISymbolType Resolve(IScope scope) {
        var st = SymbolType is UnresolvedType ut ? ut.Resolve(scope) : SymbolType;

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

        throw new NotImplementedException();
    }
}