using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {
    public override ASTNode VisitFile(SandpitParser.FileContext context) => this.Build(context);

    public override ASTNode VisitMain(SandpitParser.MainContext context) => this.Build(context);

    public override ASTNode VisitProcedureDef(SandpitParser.ProcedureDefContext context) => this.Build(context);

    public override ASTNode VisitFunctionDef(SandpitParser.FunctionDefContext context) => this.Build(context);

    public override ASTNode VisitConstantDef(SandpitParser.ConstantDefContext context) => this.Build(context);

    public override ASTNode VisitVarDef(SandpitParser.VarDefContext context) => this.Build(context);

    public override ASTNode VisitLetDef(SandpitParser.LetDefContext context) => this.Build(context);

    public override ASTNode VisitExpression(SandpitParser.ExpressionContext context) => this.Build(context);

    public override ASTNode VisitTerminal(ITerminalNode node) => this.BuildTerminal(node);

    public override ASTNode VisitParameter(SandpitParser.ParameterContext context) => this.Build(context);

    public override ASTNode VisitProcedureBlock(SandpitParser.ProcedureBlockContext context) => this.Build(context);

    public override ASTNode VisitWhile(SandpitParser.WhileContext context) => this.Build(context);

    public override ASTNode VisitProcedureStatement(SandpitParser.ProcedureStatementContext context) => this.Build(context);

}