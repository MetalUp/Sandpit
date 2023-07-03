using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST;

public static class ASTFactory {
    private static readonly IList<Func<ASTNode, ASTNode>> Rules = new List<Func<ASTNode, ASTNode>>();

    static ASTFactory() {
        Rules.Add(CompilerRules.OnlyOneMainRule);
        Rules.Add(CompilerRules.ExpressionTypeIsBooleanRule);
    }

    private static T Visit<T>(this SandpitBaseVisitor<ASTNode> visitor, IParseTree pt) where T : ASTNode => (T)visitor.Visit(pt);

    private static ASTNode ApplyRules(ASTNode node) => Rules.Aggregate(node, (current, rule) => rule(current));

    public static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParserRuleContext context) =>
        ApplyRules(context switch {
            SandpitParser.FileContext c => visitor.BuildFile(c),
            SandpitParser.ProcedureBlockContext c => visitor.BuildProcBody(c),
            SandpitParser.WhileContext c => visitor.BuildWhileStat(c),
            SandpitParser.ProcedureStatementContext c => visitor.BuildStat(c),
            //SandpitParser.ConstValContext c => visitor.BuildConstVal(c),
            //SandpitParser.FuncBodyContext c => visitor.BuildFuncBody(c),
            SandpitParser.ParameterContext c => visitor.BuildParam(c),
            SandpitParser.MainContext c => visitor.BuildMainDecl(c),
            SandpitParser.FunctionDefContext c => visitor.BuildFuncDecl(c),
            SandpitParser.ProcedureDefContext c => visitor.BuildProcDecl(c),
            SandpitParser.ConstantDefContext c => visitor.BuildConstDecl(c),
            SandpitParser.VarDefContext c => visitor.BuildVarDecl(c),
            SandpitParser.LetDefContext c => visitor.BuildLetDecl(c),
            SandpitParser.ExpressionContext c => visitor.BuildExpr(c),
            //SandpitParser.ProcedureStatementContext c => visitor.BuildProcStat(c),
            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        });

    private static FileNode BuildFile(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FileContext context) {
        var constNodes = context.constantDef().Select(visitor.Visit<ConstDeclNode>);
        var procNodes = context.procedureDef().Select(visitor.Visit<ProcNode>);
        var funcNodes = context.functionDef().Select(visitor.Visit<FuncNode>);

        var mainNodes = context.main().Select(visitor.Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes, mainNodes);
    }

    private static BodyNode BuildProcBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcedureBlockContext context) {
        var statNodes = context.procedureStatement().Select(visitor.Visit<StatNode>);
        return new BodyNode(statNodes.ToArray());
    }

    private static WhileNode BuildWhileStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.WhileContext context) {
        var expr = visitor.Visit<ValueNode>(context.condition());
        var body = visitor.Visit<BodyNode>(context.procedureBlock());

        return new WhileNode(expr, body);
    }

    private static StatNode BuildStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcedureStatementContext context) {
        if (context.varDef() is { } vd) {
            return visitor.Visit<VarDeclNode>(vd);
        }

        if (context.procedureCall() is { } ps) {
            return visitor.Visit<ProcStatNode>(ps);
        }

        return visitor.Visit<WhileNode>(context.controlFlowStatement());
    }

    //private static ValueNode BuildConstVal(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstValContext context) =>
    //    (context.INT() ?? context.BOOL() ?? context.STRING()) is { } tn ? visitor.Visit<ScalarValueNode>(tn) : new ListNode(context.constVal().Select(visitor.Visit<ValueNode>).ToArray());

    //private static FuncBodyNode BuildFuncBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FuncBodyContext context) {
    //    var letNodes = context.letDecl().Select(visitor.Visit<LetDeclNode>);
    //    var returnNode = visitor.Visit<ValueNode>(context.expr());

    //    return new FuncBodyNode(returnNode, letNodes.ToArray());
    //}

    private static ParamNode BuildParam(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ParameterContext context) =>
        new(visitor.Visit<ValueNode>(context.parameterName()), visitor.Visit<ValueNode>(context.type()));

    private static MainNode BuildMainDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.MainContext context) => new(visitor.Visit<BodyNode>(context.procedureBlock()));

    private static ProcNode BuildProcDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcedureDefContext context) {
        var idNode = visitor.Visit<ValueNode>(context.procedureSignatureAndBody().procedureName());
        var paramNodes = context.procedureSignatureAndBody().parameterList().parameter().Select(visitor.Visit<ParamNode>);
        var bodyNode = visitor.Visit<BodyNode>(context.procedureSignatureAndBody().procedureBlock());
        return new ProcNode(idNode, paramNodes.ToArray(), bodyNode);
    }

    //private static ProcStatNode BuildProcStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcStatContext context) {
    //    var idNode = visitor.Visit<ValueNode>(context.ID());
    //    var paramNodes = context.expr().Select(visitor.Visit<ValueNode>);
    //    return new ProcStatNode(idNode, paramNodes.ToArray());
    //}

    private static FuncNode BuildFuncDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FunctionDefContext context) {
        var idNode = visitor.Visit<ValueNode>(context.functionSignatureAndBody().functionName());
        var paramNodes = context.functionSignatureAndBody().parameterList().parameter().Select(visitor.Visit<ParamNode>);
        var typeNode = visitor.Visit<ValueNode>(context.functionSignatureAndBody().type());
        //var bodyNode = visitor.Visit<FuncBodyNode>(context.functionSignatureAndBody().letDef());

        return new FuncNode(idNode, typeNode, paramNodes.ToArray(), null);
    }

    private static ConstDeclNode BuildConstDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstantDefContext context) => new(visitor.Visit<ValueNode>(context.constantName()), visitor.Visit<ValueNode>(context.expression()));

    private static VarDeclNode BuildVarDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.VarDefContext context) => new(visitor.Visit<ValueNode>(context.variableName()), visitor.Visit<ValueNode>(context.expression()));

    private static LetDeclNode BuildLetDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.LetDefContext context) => new(visitor.Visit<ValueNode>(context.letName()), visitor.Visit<ValueNode>(context.expression()));

    private static ValueNode BuildExpr(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ExpressionContext context) {
        if (context.simpleExpression() is { } id) {
            return visitor.Visit<ScalarValueNode>(id);
        }

        //if (context.expression() is { } cv) {
        //    return visitor.Visit<ScalarValueNode>(cv);
        //}

        var lhs = visitor.Visit<ValueNode>(context.expression().First());
        var rhs = visitor.Visit<ValueNode>(context.expression().Last());
        var op = visitor.Visit<ValueNode>(context.binaryOp());

        return new BinaryOperatorNode(op!, lhs, rhs);
    }

    public static ScalarValueNode BuildTerminal(this SandpitBaseVisitor<ASTNode> visitor, ITerminalNode node) => new(node.Symbol);
}