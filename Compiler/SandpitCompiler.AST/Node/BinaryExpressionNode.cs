using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

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

    public ISymbolType SymbolType => Op.Operator switch {
        Constants.Operators.Eq or Constants.Operators.Ne => new BuiltInType("Bool"), // TODO get from Symbol table ? 
        _ => throw new NotImplementedException()
    };
}