using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

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
            SandpitParser.ProcBodyContext c => visitor.BuildProcBody(c),
            SandpitParser.WhileStatContext c => visitor.BuildWhileStat(c),
            SandpitParser.StatContext c => visitor.BuildStat(c),
            SandpitParser.ConstValContext c => visitor.BuildConstVal(c),
            SandpitParser.FuncBodyContext c => visitor.BuildFuncBody(c),
            SandpitParser.ParamContext c => visitor.BuildParam(c),
            SandpitParser.MainDeclContext c => visitor.BuildMainDecl(c),
            SandpitParser.FuncDeclContext c => visitor.BuildFuncDecl(c),
            SandpitParser.ProcDeclContext c => visitor.BuildProcDecl(c),
            SandpitParser.ConstDeclContext c => visitor.BuildConstDecl(c),
            SandpitParser.VarDeclContext c => visitor.BuildVarDecl(c),
            SandpitParser.LetDeclContext c => visitor.BuildLetDecl(c),
            SandpitParser.ExprContext c => visitor.BuildExpr(c),
            SandpitParser.ProcStatContext c => visitor.BuildProcStat(c),
            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        });

    private static FileNode BuildFile(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FileContext context) {
        var constNodes = context.constDecl().Select(visitor.Visit<ConstDeclNode>);
        var procNodes = context.procDecl().Select(visitor.Visit<ProcNode>);
        var funcNodes = context.funcDecl().Select(visitor.Visit<FuncNode>);

        var mainNodes = context.mainDecl().Select(visitor.Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes, mainNodes);
    }

    private static BodyNode BuildProcBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcBodyContext context) {
        var statNodes = context.stat().Select(visitor.Visit<StatNode>);
        return new BodyNode(statNodes.ToArray());
    }

    private static WhileNode BuildWhileStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.WhileStatContext context) {
        var expr = visitor.Visit<ValueNode>(context.expr());
        var body = visitor.Visit<BodyNode>(context.procBody());

        return new WhileNode(expr, body);
    }

    private static StatNode BuildStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.StatContext context) {
        if (context.varDecl() is { } vd) {
            return visitor.Visit<VarDeclNode>(vd);
        }
        else if (context.procStat() is { } ps) {
            return visitor.Visit<ProcStatNode>(ps);
        }
        else {
            return visitor.Visit<WhileNode>(context.whileStat());
        }
    }

    private static ValueNode BuildConstVal(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstValContext context) =>
        (context.INT()?? context.BOOL() ?? context.STRING()) is { } tn ? visitor.Visit<ScalarValueNode>(tn) : new ListNode(context.constVal().Select(visitor.Visit<ValueNode>).ToArray());

    private static FuncBodyNode BuildFuncBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FuncBodyContext context) {
        var letNodes = context.letDecl().Select(visitor.Visit<LetDeclNode>);
        var returnNode = visitor.Visit<ValueNode>(context.expr());

        return new FuncBodyNode(returnNode, letNodes.ToArray());
    }

    private static ParamNode BuildParam(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ParamContext context) =>
        new(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.type()));

    private static MainNode BuildMainDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.MainDeclContext context) => new(visitor.Visit<BodyNode>(context.procBody()));

    private static ProcNode BuildProcDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcDeclContext context) {
        var idNode = visitor.Visit<ValueNode>(context.ID());
        var paramNodes = context.param().Select(visitor.Visit<ParamNode>);
        var bodyNode = visitor.Visit<BodyNode>(context.procBody());
        return new ProcNode(idNode, paramNodes.ToArray(), bodyNode);
    }

    private static ProcStatNode BuildProcStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcStatContext context) {
        var idNode = visitor.Visit<ValueNode>(context.ID());
        var paramNodes = context.expr().Select(visitor.Visit<ValueNode>);
        return new ProcStatNode(idNode, paramNodes.ToArray());
    }

    private static FuncNode BuildFuncDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FuncDeclContext context) {
        var idNode = visitor.Visit<ValueNode>(context.ID());
        var paramNodes = context.param().Select(visitor.Visit<ParamNode>);
        var typeNode = visitor.Visit<ValueNode>(context.type());
        var bodyNode = visitor.Visit<FuncBodyNode>(context.funcBody());

        return new FuncNode(idNode, typeNode, paramNodes.ToArray(), bodyNode);
    }

    private static ConstDeclNode BuildConstDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstDeclContext context) => new(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.constVal()));

    private static VarDeclNode BuildVarDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.VarDeclContext context) => new(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.expr()));

    private static LetDeclNode BuildLetDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.LetDeclContext context) => new(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.expr()));

    private static ValueNode BuildExpr(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ExprContext context) {
        if (context.ID() is { } id) {
            return visitor.Visit<ScalarValueNode>(id);
        }

        if (context.constVal() is { } cv) {
            return visitor.Visit<ScalarValueNode>(cv);
        }

        var lhs = visitor.Visit<ValueNode>(context.expr().First());
        var rhs = visitor.Visit<ValueNode>(context.expr().Last());
        var op = visitor.Visit<ValueNode>(context.GetChild(1));

        return new BinaryOperatorNode(op!, lhs, rhs);
    }

    public static ScalarValueNode BuildTerminal(this SandpitBaseVisitor<ASTNode> visitor, ITerminalNode node) => new(node.Symbol);
}