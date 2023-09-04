using System;
using System.Collections.Immutable;
using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Model;
using SandpitCompiler.Model.Model;

namespace SandpitCompiler;

public class SecondPassASTVisitor {
    private IScope currentScope;

    public SecondPassASTVisitor(SymbolTable symbolTable) {
        SymbolTable = symbolTable;
        currentScope = symbolTable.GlobalScope;
    }

    public IList<string> CompileErrors = new List<string>();

    private SymbolTable SymbolTable { get; }

    private static IList<Func<IASTNode[], IScope, string?>> Rules { get; } = new List<Func<IASTNode[], IScope, string?>>();

    static SecondPassASTVisitor() {
        Rules.Add(CompilerRules.OnlyOneMainRule);
        Rules.Add(CompilerRules.ExpressionTypeIsBooleanRule);
        Rules.Add(CompilerRules.NoProcedureInFunctionRule);
        Rules.Add(CompilerRules.ExpressionMustBeAssignedRule);
    }

    private void Enter(IASTNode node) {
        switch (node) {
            case IBlock:
                currentScope = currentScope.Resolve("main") as IScope ?? throw new ArgumentNullException();
                break;
            case IProcedure p:
                currentScope = currentScope.Resolve(p.ID.Text) as IScope ?? throw new ArgumentNullException();
                break;
            case IFunction f:
                currentScope = currentScope.Resolve(f.ID.Text) as IScope ?? throw new ArgumentNullException();
                break;
            case LetDefnNode l:
                currentScope = currentScope.ChildScopes.FirstOrDefault() ?? throw new ArgumentNullException();
                break;
        }
    }

    private void Exit(IASTNode node) {
        if (node is IBlock or IProcedure or IFunction or LetDefnNode) {
            currentScope = currentScope.EnclosingScope ?? throw new ArgumentNullException();
        }
    }

    private void ApplyRules(IASTNode[] nodes, IScope scope) {
        foreach (var rule in Rules) {
            if (rule(nodes, scope) is {} e) {
                CompileErrors.Add(e);
            }
        }
    }

    public void Visit(IASTNode[] nodeHierarchy) {
        var currentNode = nodeHierarchy.Last();

        Enter(currentNode);
        try {
            ApplyRules(nodeHierarchy, currentScope);
            foreach (var child in currentNode.Children) {
                var tree = nodeHierarchy.Append(child).ToArray();
                Visit(tree);
            }
        }
        finally {
            Exit(currentNode);
        }
    }

}