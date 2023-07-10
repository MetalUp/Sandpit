using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class OperatorValueNode : ValueNode {
    public OperatorValueNode(IToken nodeSymbol) : base(nodeSymbol) => SymbolType = ASTHelpers.TokenToType(nodeSymbol);

    public override IList<IASTNode> Children { get; } = new List<IASTNode>();
    public Constants.Operators Operator => ASTHelpers.MapSymbolToOperator(TokenName);

    public override ISymbolType SymbolType { get; }

    public override string ToString() {
        var typeName = GetType().Name;
        return $"<{typeName}, '{Operator}'>";
    }
}