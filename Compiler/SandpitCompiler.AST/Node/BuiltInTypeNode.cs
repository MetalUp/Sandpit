using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class BuiltInTypeNode : TypeNode {
    public BuiltInTypeNode(IToken? nodeSymbol) : base(nodeSymbol) { }

    public override IList<IASTNode> Children => Array.Empty<IASTNode>();
    public override string ToStringTree() => ToString();
}