using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class ListValueNode : ASTNode, IExpression {
    public ListValueNode(params ValueNode[] valueNodes)  => Children = ValueNodes = valueNodes;

    private ValueNode[] ValueNodes { get; }

    public string[] Texts => ValueNodes.Select(vn => vn.Text).ToArray();

    public override IList<IASTNode> Children { get; }

    public override string ToString() {
        var typeName = GetType().Name;
        return typeName;
    }

    public ISymbolType SymbolType => new ListType(ValueNodes.First().SymbolType);

    public override string ToStringTree() => $"({ToString()} {ValueNodes.AsString()})";
}