using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {
    public override ASTNode VisitFile(SandpitParser.FileContext context) => this.BuildFile(context);

    public override ASTNode VisitMainDecl(SandpitParser.MainDeclContext context) => this.BuildMainDecl(context);

    public override ASTNode VisitProcDecl(SandpitParser.ProcDeclContext context) => this.BuildProcDecl(context);

    public override ASTNode VisitFuncDecl(SandpitParser.FuncDeclContext context) => this.BuildFuncDecl(context);

    public override ASTNode VisitConstDecl(SandpitParser.ConstDeclContext context) => this.BuildConstDecl(context);

    public override ASTNode VisitVarDecl(SandpitParser.VarDeclContext context) => this.BuildVarDecl(context);

    public override ASTNode VisitLetDecl(SandpitParser.LetDeclContext context) => this.BuildLetDecl(context);

    public override ASTNode VisitExpr(SandpitParser.ExprContext context) => this.BuildExpr(context);

    public override ASTNode VisitTerminal(ITerminalNode node) => this.BuildTerminal(node);

    public override ASTNode VisitParam(SandpitParser.ParamContext context) => this.BuildParam(context);

    public override ASTNode VisitFuncBody(SandpitParser.FuncBodyContext context) => this.BuildFuncBody(context);

    public override ASTNode VisitProcBody(SandpitParser.ProcBodyContext context) => this.BuildProcBody(context);

    public override ASTNode VisitConstVal(SandpitParser.ConstValContext context) => this.BuildConstVal(context);

    public override ASTNode VisitWhileStat(SandpitParser.WhileStatContext context) => this.BuildWhileStat(context);

    public override ASTNode VisitStat(SandpitParser.StatContext context) => this.BuildStat(context);
}