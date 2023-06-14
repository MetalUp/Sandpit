using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {

   

    public override ASTNode VisitFile(SandpitParser.FileContext context) {
        var constNodes = context.constDecl().Select(Visit);
        var procNodes = context.procDecl().Select(Visit);

        var mainDecls = context.mainDecl();
        if (mainDecls.Count() > 1) {
            throw new CompileErrorException("more than one main");
        }

        var mainNodes = mainDecls.Select(Visit);
        return new FileNode(constNodes, procNodes, mainNodes.SingleOrDefault());
    }

    public override ASTNode VisitMainDecl(SandpitParser.MainDeclContext context) {
        var varNodes = context.varDecl().Select(Visit);
        return new MainNode(varNodes);
    }

    public override ASTNode VisitProcDecl(SandpitParser.ProcDeclContext context) {
        var varNodes = context.varDecl().Select(Visit);
        return new ProcNode(varNodes);
    }

    public override ASTNode VisitConstDecl(SandpitParser.ConstDeclContext context) => new ConstDeclNode(Visit(context.ID()), Visit(context.INT()));

    public override ASTNode VisitVarDecl(SandpitParser.VarDeclContext context) => new VarDeclNode(Visit(context.ID()), Visit(context.expr()));

    public override ASTNode VisitExpr(SandpitParser.ExprContext context) => Visit(context.ID() ?? context.INT());

    public override ASTNode VisitChildren(IRuleNode node) => base.VisitChildren(node);

    public override ASTNode VisitErrorNode(IErrorNode node) => base.VisitErrorNode(node);

    private static bool IsBinaryOperator(ASTNode astNode) => astNode.Text is "-" or "+" or "*" or "==";

    public override ASTNode VisitTerminal(ITerminalNode node) => new ValueNode(node.Symbol);
}