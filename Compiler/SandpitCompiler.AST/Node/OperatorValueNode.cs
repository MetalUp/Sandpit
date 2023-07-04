using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class OperatorValueNode : ValueNode {
    public OperatorValueNode(IToken? nodeSymbol) : base(nodeSymbol) { }
    public override IList<IASTNode> Children { get; } = new List<IASTNode>();
    public Constants.Operators Operator => ASTHelpers.MapSymbolToOperator(TokenName);
}