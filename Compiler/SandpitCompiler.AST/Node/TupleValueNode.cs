using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class TupleValueNode : ASTNode, IExpression {
    public TupleValueNode(params IExpression[] valueNodes) => Children = ValueNodes = valueNodes;

    public IExpression[] ValueNodes { get; }

    public override IList<IASTNode> Children { get; }

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public ISymbolType SymbolType => new TupleType(ValueNodes.Select(n => n.SymbolType).ToArray());

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}