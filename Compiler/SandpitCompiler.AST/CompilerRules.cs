using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static ASTNode OnlyOneMainRule(ASTNode node) {
        if (node is FileNode { MainNode.Length: > 1 }) {
            throw new CompileErrorException("more than one main");
        }

        return node;
    }

    public static ASTNode ExpressionTypeIsBooleanRule(ASTNode node) {
        if (node is WhileNode wn) {
            return wn.Condition switch {
                ScalarValueNode { InferredType: "BOOL" } => node,
                BinaryOperatorNode { Op.Text: "==" } => node,
                _ => throw new CompileErrorException("control expression must be bool")
            };
        }

        return node;
    }
}