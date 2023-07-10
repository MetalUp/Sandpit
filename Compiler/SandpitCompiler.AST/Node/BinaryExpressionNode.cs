using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class BinaryExpressionNode : ASTNode, IExpression {
    public BinaryExpressionNode(OperatorValueNode op, IExpression lhs, IExpression rhs) {
        Op = op;
        Lhs = lhs;
        Rhs = rhs;
        Children = new List<IASTNode> { op, lhs, rhs };
    }

    public OperatorValueNode Op { get; }
    public IExpression Lhs { get; }
    public IExpression Rhs { get; }

    public override IList<IASTNode> Children { get; }

    public override string ToStringTree() => $"({ToString()}{Op.ToStringTree()}{Lhs.ToStringTree()}{Rhs.ToStringTree()})";

    public ISymbolType SymbolType => throw new NotImplementedException();

}