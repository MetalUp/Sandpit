using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace SandpitCompiler.AST;

public static class ASTFactory {
    private static T Visit<T>(this SandpitBaseVisitor<ASTNode> visitor, IParseTree pt) where T : ASTNode => (T)visitor.Visit(pt);

    private static SandpitParser.MainDeclContext[] OnlyOneMainRule(SandpitParser.MainDeclContext[] mainDecls) {
        if (mainDecls.Count() > 1) {
            throw new CompileErrorException("more than one main");
        }

        return mainDecls;
    }

    public static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParserRuleContext context) {
        return context switch {
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
            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        };
    }

    private static ASTNode BuildFile(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FileContext context) {
        var mainDecls = OnlyOneMainRule(context.mainDecl());

        var constNodes = context.constDecl().Select(visitor.Visit<ConstDeclNode>);
        var procNodes = context.procDecl().Select(visitor.Visit<ProcNode>);
        var funcNodes = context.funcDecl().Select(visitor.Visit<FuncNode>);

        var mainNodes = mainDecls.Select(visitor.Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes, mainNodes.SingleOrDefault());
    }

    private static ASTNode BuildProcBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcBodyContext context) {
        var statNodes = context.stat().Select(visitor.Visit<StatNode>);
        return new BodyNode(statNodes.ToArray());
    }

    private static ASTNode BuildWhileStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.WhileStatContext context) {
        var expr = visitor.Visit<ValueNode>(context.expr());
        var body = visitor.Visit<BodyNode>(context.procBody());

        return new WhileNode(expr, body);
    }

    private static ASTNode BuildStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.StatContext context) =>
        context.varDecl() is { } vd ? visitor.Visit(vd) : visitor.Visit(context.whileStat());

    private static ASTNode BuildConstVal(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstValContext context) =>
        (context.INT() ?? context.STRING()) is { } tn ? visitor.Visit(tn) : new ListNode(context.constVal().Select(visitor.Visit<ValueNode>).ToArray());

    private static ASTNode BuildFuncBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FuncBodyContext context) {
        var letNodes = context.letDecl().Select(visitor.Visit<LetDeclNode>);
        var returnNode = visitor.Visit<ValueNode>(context.expr());

        return new FuncBodyNode(returnNode, letNodes.ToArray());
    }

    private static ASTNode BuildParam(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ParamContext context) =>
        new ParamNode(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.type()));

    private static ASTNode BuildMainDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.MainDeclContext context) => new MainNode(visitor.Visit<BodyNode>(context.procBody()));

    private static ASTNode BuildProcDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcDeclContext context) {
        var idNode = visitor.Visit<ValueNode>(context.ID());
        var paramNodes = context.param().Select(visitor.Visit<ParamNode>);
        var bodyNode = visitor.Visit<BodyNode>(context.procBody());
        return new ProcNode(idNode, paramNodes.ToArray(), bodyNode);
    }

    private static ASTNode BuildFuncDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.FuncDeclContext context) {
        var idNode = visitor.Visit<ValueNode>(context.ID());
        var paramNodes = context.param().Select(visitor.Visit<ParamNode>);
        var typeNode = visitor.Visit<ValueNode>(context.type());
        var bodyNode = visitor.Visit<FuncBodyNode>(context.funcBody());

        return new FuncNode(idNode, typeNode, paramNodes.ToArray(), bodyNode);
    }

    private static ASTNode BuildConstDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ConstDeclContext context) => new ConstDeclNode(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.constVal()));

    private static ASTNode BuildVarDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.VarDeclContext context) => new VarDeclNode(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.expr()));

    private static ASTNode BuildLetDecl(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.LetDeclContext context) => new LetDeclNode(visitor.Visit<ValueNode>(context.ID()), visitor.Visit<ValueNode>(context.expr()));

    private static ASTNode BuildExpr(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ExprContext context) {
        if (context.ID() is { } id) {
            return visitor.Visit(id);
        }

        if (context.constVal() is { } cv) {
            return visitor.Visit(cv);
        }

        var lhs = visitor.Visit<ValueNode>(context.expr().First());
        var rhs = visitor.Visit<ValueNode>(context.expr().Last());
        var op = visitor.Visit<ValueNode>(context.GetChild(1));

        return new BinaryOperatorNode(op!, lhs, rhs);
    }

    public static ASTNode BuildTerminal(this SandpitBaseVisitor<ASTNode> visitor, ITerminalNode node) => new ScalarValueNode(node.Symbol);
}