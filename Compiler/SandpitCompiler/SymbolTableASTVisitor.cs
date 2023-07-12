using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler;

public class SymbolTableASTVisitor {
    private IScope currentScope;

    public SymbolTableASTVisitor() => currentScope = SymbolTable.GlobalScope;

    public SymbolTable SymbolTable { get; } = new();

    public IASTNode Visit(IASTNode astNode) {
        return astNode switch {
            IDefinition dn => VisitDeclNode(dn),
            IBlock bn => VisitBlockNode(bn),
            IProcedure pn => VisitProcNode(pn),
            IFunction fn => VisitFunctionNode(fn),
            LetDefnNode ln => VisitLetNode(ln),
            FileNode fn => VisitChildren(fn),
            ValueNode vn => VisitChildren(vn),
            WhileStatementNode sn => VisitChildren(sn),
            ProcedureStatementNode sn => VisitChildren(sn),
            null => throw new NotImplementedException("null"),
            _ => VisitChildren(astNode)
        };
    }

    private IASTNode VisitLetNode(LetDefnNode ln) {
        var ms = new MethodSymbol("", ln.SymbolType, currentScope);
        currentScope.Define(ms);
        currentScope = ms;

        foreach (var (id, expr) in ln.Values) {
            var vs = new VariableSymbol(id.Text, expr.SymbolType);
            currentScope.Define(vs);
        }


        currentScope = currentScope.EnclosingScope ?? throw new Exception("unexpected null scope");
        return ln;
    }

    private IASTNode VisitDeclNode(IDefinition dn) {
        var vs = new VariableSymbol(dn.Id, dn.SymbolType);
        currentScope.Define(vs);
        return dn;
    }

    private IASTNode VisitBlockNode(IBlock bn) {
        var ms = new MethodSymbol("main", null, currentScope);
        currentScope.Define(ms);
        currentScope = ms;
        VisitChildren(bn);
        currentScope = currentScope.EnclosingScope ?? throw new Exception("unexpected null scope");
        return bn;
    }

    private IASTNode VisitProcNode(IProcedure pn) {
        var ms = new MethodSymbol(pn.ID.Text, null, currentScope);
        currentScope.Define(ms);
        currentScope = ms;
        VisitChildren(pn);
        currentScope = currentScope.EnclosingScope ?? throw new Exception("unexpected null scope");
        return pn;
    }

    private IASTNode VisitFunctionNode(IFunction pn) {
        var ms = new MethodSymbol(pn.ID.Text, pn.SymbolType, currentScope);
        currentScope.Define(ms);
        currentScope = ms;
        VisitChildren(pn);
        currentScope = currentScope.EnclosingScope ?? throw new Exception("unexpected null scope");
        return pn;
    }

    private IASTNode VisitChildren(IASTNode node) {
        foreach (var child in node.Children) {
            Visit(child);
        }

        return node;
    }
}