using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class ScalarValueNode : ValueNode {
    public ScalarValueNode(IToken nodeSymbol) : base(nodeSymbol) { }
    public override IList<IASTNode> Children { get; } = new List<IASTNode>();
    public override string ToStringTree() => ToString();
}