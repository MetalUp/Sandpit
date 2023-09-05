using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST;

public static class CompilerRules {
    public static string? OnlyOneMainRule(IASTNode[] nodes, IScope currentScope) {
        var node = nodes.Last();

        return node is FileNode { MainNode.Length: > 1 } ? "more than one main" : null;
    }

    public static string? ExpressionTypeIsBooleanRule(IASTNode[] nodes, IScope currentScope) {
        var node = nodes.Last();

        if (node is WhileStatementNode wn) {
            return wn.Condition switch {
                // TODO rework to 'resolve' the type of the expression
                ScalarValueNode { SymbolType: BuiltInType { Name : "Bool" } } => null,
                BinaryExpressionNode { Op.Operator: Constants.Operators.Eq or Constants.Operators.Ne } => null,
                _ => "control expression must be bool"
            };
        }

        return null;
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

    // TODO this is a hack - really need to understand better the semantics - may require refining the AST
    public static string? ExpressionMustBeAssignedRule(IASTNode[] nodes, IScope currentScope) {
        var leafNode = nodes.Last();

        if (leafNode is MethodStatementNode msn && currentScope.Resolve(msn.ID.Text) is MethodSymbol { MethodType: MethodType.Function }) {
            var otherNodes = nodes.SkipLast(1).ToArray();
            if (!otherNodes.Any(n => n is AssignmentNode or TernaryExpressionNode or LambdaExpressionNode or LetDefnNode or VarDefinitionNode || (n is FunctionDefinitionNode fdn && fdn.ReturnExpression == leafNode))
                && otherNodes.Last() is not MethodStatementNode) {
                return "Cannot have unassigned expression";
            }
        }

        return null;
    }
}