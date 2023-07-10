using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LambdaValueNode : ASTNode, IExpression {
    public ValueNode[] Args { get; }
    public IExpression Expr { get; }

    public LambdaValueNode(ValueNode[] args,  IExpression expr) {
        Args = args;
        Expr = expr;
        Children = new List<IASTNode> { expr };
    }

    public override IList<IASTNode> Children { get; }
  
    public override string ToStringTree() => $"({ToString()}{Expr.ToStringTree()})";
    public ISymbolType SymbolType => throw new NotImplementedException() ;
}