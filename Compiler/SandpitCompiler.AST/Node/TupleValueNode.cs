using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class TupleValueNode : ValueNode {
    public TupleValueNode(params ValueNode[] valueNodes) : base(valueNodes.Any() ? valueNodes.First().Token : null) => Children = ValueNodes = valueNodes;

    public ValueNode[] ValueNodes { get; }

    public string[] Texts => ValueNodes.Select(vn => vn.Text).ToArray();

    public override IList<IASTNode> Children { get; }

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public override ISymbolType SymbolType => new TupleType(ValueNodes.Select(n => n.SymbolType).ToArray());

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}