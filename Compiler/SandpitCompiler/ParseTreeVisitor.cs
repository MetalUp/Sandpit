using System.Runtime.CompilerServices;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {

    private T Visit<T>(IParseTree pt)  where T : ASTNode => (T)Visit(pt); 


    private static SandpitParser.MainDeclContext[] OnlyOneMainRule(SandpitParser.MainDeclContext[] mainDecls) {
        if (mainDecls.Count() > 1) {
            throw new CompileErrorException("more than one main");
        }

        return mainDecls;
    }

    public override ASTNode VisitFile(SandpitParser.FileContext context) {
        var mainDecls = OnlyOneMainRule(context.mainDecl());
        
        var constNodes = context.constDecl().Select(Visit<ConstDeclNode>);
        var procNodes = context.procDecl().Select(Visit<ProcNode>);
        var funcNodes = context.funcDecl().Select(Visit<FuncNode>);

        var mainNodes = mainDecls.Select(Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes,  mainNodes.SingleOrDefault());
    }

    public override ASTNode VisitMainDecl(SandpitParser.MainDeclContext context) {
        var varNodes = context.varDecl().Select(Visit<VarDeclNode>);
        return new MainNode(varNodes.ToArray());
    }

    public override ASTNode VisitProcDecl(SandpitParser.ProcDeclContext context) {
        var varNodes = context.varDecl().Select(Visit<VarDeclNode>);
        return new ProcNode(Visit<ValueNode>(context.ID()), varNodes.ToArray());
    }

    public override ASTNode VisitFuncDecl(SandpitParser.FuncDeclContext context) {
        var letNodes = context.letDecl().Select(Visit<LetDeclNode>);
        return new FuncNode(Visit<ValueNode>(context.ID()), letNodes.ToArray());
    }

    public override ASTNode VisitConstDecl(SandpitParser.ConstDeclContext context) => new ConstDeclNode(Visit<ValueNode>(context.ID()), Visit<ValueNode>(context.INT()));

    public override ASTNode VisitVarDecl(SandpitParser.VarDeclContext context) => new VarDeclNode(Visit<ValueNode>(context.ID()), Visit<ValueNode>(context.expr()));

    public override ASTNode VisitLetDecl(SandpitParser.LetDeclContext context) => new LetDeclNode(Visit<ValueNode>(context.ID()), Visit<ValueNode>(context.expr()));

    public override ASTNode VisitExpr(SandpitParser.ExprContext context) => Visit(context.ID() ?? context.INT());

    public override ASTNode VisitChildren(IRuleNode node) => base.VisitChildren(node);

    public override ASTNode VisitErrorNode(IErrorNode node) => base.VisitErrorNode(node);

    private static bool IsBinaryOperator(ASTNode astNode) => astNode.Text is "-" or "+" or "*" or "==";

    public override ASTNode VisitTerminal(ITerminalNode node) => new ValueNode(node.Symbol);
}