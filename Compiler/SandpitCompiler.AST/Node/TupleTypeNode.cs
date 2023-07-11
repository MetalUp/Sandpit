using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class TupleTypeNode : TypeNode {
    public TupleTypeNode(IEnumerable<TypeNode> items) : base(null) => Items = items.ToList();

    public IList<TypeNode> Items { get; }

    public override IList<IASTNode> Children => Items.OfType<IASTNode>().ToList();
    public override ISymbolType SymbolType => new TupleType(Items.Select(i => i.SymbolType).ToArray());
    public override string ToStringTree() => ToString();
}