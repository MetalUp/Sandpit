using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static IASTNode OnlyOneMainRule(IASTNode node) {
        if (node is FileNode { MainNode.Length: > 1 }) {
            throw new CompileErrorException("more than one main");
        }

        return node;
    }

    public static IASTNode ExpressionTypeIsBooleanRule(IASTNode node) {
        if (node is WhileStatementNode wn) {
            return wn.Condition switch {
                // TODO rework to 'resolve' the type of the expression
                ScalarValueNode { SymbolType: BuiltInType { Name : "Bool" } } => node,
                BinaryExpressionNode { Op.Operator: Constants.Operators.Eq or Constants.Operators.Ne } => node,
                _ => throw new CompileErrorException("control expression must be bool")
            };
        }

        return node;
    }

    public static string? NoProcedureInFunctionRule(IASTNode[] nodes, IScope currentScope) {
        var leafNode = nodes.Last();

        if (leafNode is MethodStatementNode msn) {
            if (currentScope.Resolve(msn.ID.Text) is MethodSymbol { MethodType: MethodType.Procedure or MethodType.SystemCall }) {
                if (nodes.Any(n => n is FunctionDefinitionNode)) {
                    return "Cannot have procedure/system call in function";
                }
            }
        }

        return null;
    }
}