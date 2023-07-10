using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class BuiltInTypeNode : TypeNode {
    public BuiltInTypeNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public override IList<IASTNode> Children => Array.Empty<IASTNode>();
    public override string ToStringTree() => ToString();
    public override ISymbolType SymbolType => ASTHelpers.TokenToType(Token ?? throw new ArgumentNullException());
}