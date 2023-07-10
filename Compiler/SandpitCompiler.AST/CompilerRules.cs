using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static IASTNode OnlyOneMainRule(IASTNode node) {
        if (node is FileNode { MainNode.Length: > 1 }) {
            throw new CompileErrorException("more than one main");
        }

        return node;
    }

    public static IASTNode ExpressionTypeIsBooleanRule(IASTNode node) {
        if (node is WhileStatNode wn) {
            return wn.Condition switch {
                // TODO rework to 'resolve' the type of the expression
                ScalarValueNode { SymbolType: BuiltInType { Name : "Bool" } } => node,
                BinaryValueNode { Op.Operator: Constants.Operators.Eq or Constants.Operators.Ne } => node,
                _ => throw new CompileErrorException("control expression must be bool")
            };
        }

        return node;
    }
}