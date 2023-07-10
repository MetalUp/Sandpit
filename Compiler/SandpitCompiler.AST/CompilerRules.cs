using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static ASTNode OnlyOneMainRule(ASTNode node) {
        if (node is FileNode { MainNode.Length: > 1 }) {
            throw new CompileErrorException("more than one main");
        }

        return node;
    }

    public static ASTNode ExpressionTypeIsBooleanRule(ASTNode node)
    {
        if (node is WhileStatNode wn)
        {
            return wn.Condition switch
            {
                // TODO rework to 'resolve' the type of the expression
                ScalarValueNode { InferredType.TokenName: "BOOL_VALUE" } => node,
                BinaryValueNode { Op.Operator: Constants.Operators.Eq or Constants.Operators.Ne } => node,
                _ => throw new CompileErrorException("control expression must be bool")
            };
        }

        return node;
    }
}