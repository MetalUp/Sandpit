using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class ScalarValueNode : ValueNode {
    public ScalarValueNode(IToken nodeSymbol) : base(nodeSymbol) => SymbolType = ASTHelpers.TokenToType(nodeSymbol);

    public override IList<IASTNode> Children { get; } = new List<IASTNode>();

    public override ISymbolType SymbolType { get; }
    public override string ToStringTree() => ToString();
}