using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler;

public class SecondPassASTVisitor {
    public IList<string> CompileErrors = new List<string>();
    private IScope currentScope;

    static SecondPassASTVisitor() {
        Transforms.Add(CompilerRules.ResolveGenericsTransform);

        Rules.Add(CompilerRules.OnlyOneMainRule);
        Rules.Add(CompilerRules.ExpressionTypeIsBooleanRule);
        Rules.Add(CompilerRules.NoProcedureInFunctionRule);
        Rules.Add(CompilerRules.ExpressionMustBeAssignedRule);
        Rules.Add(CompilerRules.TypeAssignmentRule);
    }

    public SecondPassASTVisitor(SymbolTable symbolTable) {
        SymbolTable = symbolTable;
        currentScope = symbolTable.GlobalScope;
    }

    private SymbolTable SymbolTable { get; }

    private static IList<Func<IASTNode[], IScope, string?>> Rules { get; } = new List<Func<IASTNode[], IScope, string?>>();

    private static IList<Func<IASTNode[], IScope, string?>> Transforms { get; } = new List<Func<IASTNode[], IScope, string?>>();

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
            if (rule(nodes, scope) is { } e) {
                CompileErrors.Add(e);
            }
        }
    }

    private void ApplyTransforms(IASTNode[] nodes, IScope scope) {
        foreach (var rule in Transforms) {
            rule(nodes, scope);
        }
    }

    private void Visit(IASTNode[] nodeHierarchy, Action<IASTNode[], IScope> action) {
        var currentNode = nodeHierarchy.Last();

        Enter(currentNode);
        try {
            action(nodeHierarchy, currentScope);
            foreach (var child in currentNode.Children) {
                var tree = nodeHierarchy.Append(child).ToArray();
                Visit(tree, action);
            }
        }
        finally {
            Exit(currentNode);
        }
    }


    public void Visit(IASTNode[] nodeHierarchy) {
       Visit(nodeHierarchy, ApplyTransforms);
       Visit(nodeHierarchy, ApplyRules);
    }
}