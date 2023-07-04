using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.SymbolTree;

namespace SandpitCompiler;

public class SymbolTableASTVisitor {
    private IScope currentScope;

    public SymbolTableASTVisitor() => currentScope = SymbolTable.GlobalScope;

    public SymbolTable SymbolTable { get; } = new();

    public IASTNode Visit(IASTNode astNode) {
        return astNode switch {
            IDecl dn => VisitDeclNode(dn),
            IBlock bn => VisitBlockNode(bn),
            IProc pn => VisitProcNode(pn),
            FileNode fn => VisitChildren(fn),
            ValueNode vn => VisitChildren(vn),
            WhileStatNode sn => VisitChildren(sn),
            ProcStatNode sn => VisitChildren(sn),
            null => throw new NotImplementedException("null"),
            _ => VisitChildren(astNode)
        };
    }

    private IASTNode VisitDeclNode(IDecl dn) {
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

    private IASTNode VisitProcNode(IProc pn) {
        var ms = new MethodSymbol(pn.ID.Text, null, currentScope);
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