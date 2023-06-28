using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {
    public override ASTNode VisitFile(SandpitParser.FileContext context) => this.Build(context);

    public override ASTNode VisitMainDecl(SandpitParser.MainDeclContext context) => this.Build(context);

    public override ASTNode VisitProcDecl(SandpitParser.ProcDeclContext context) => this.Build(context);

    public override ASTNode VisitFuncDecl(SandpitParser.FuncDeclContext context) => this.Build(context);

    public override ASTNode VisitConstDecl(SandpitParser.ConstDeclContext context) => this.Build(context);

    public override ASTNode VisitVarDecl(SandpitParser.VarDeclContext context) => this.Build(context);

    public override ASTNode VisitLetDecl(SandpitParser.LetDeclContext context) => this.Build(context);

    public override ASTNode VisitExpr(SandpitParser.ExprContext context) => this.Build(context);

    public override ASTNode VisitTerminal(ITerminalNode node) => this.BuildTerminal(node);

    public override ASTNode VisitParam(SandpitParser.ParamContext context) => this.Build(context);

    public override ASTNode VisitFuncBody(SandpitParser.FuncBodyContext context) => this.Build(context);

    public override ASTNode VisitProcBody(SandpitParser.ProcBodyContext context) => this.Build(context);

    public override ASTNode VisitConstVal(SandpitParser.ConstValContext context) => this.Build(context);

    public override ASTNode VisitWhileStat(SandpitParser.WhileStatContext context) => this.Build(context);

    public override ASTNode VisitStat(SandpitParser.StatContext context) => this.Build(context);

    public override ASTNode VisitProcStat(SandpitParser.ProcStatContext context) => this.Build(context);
}