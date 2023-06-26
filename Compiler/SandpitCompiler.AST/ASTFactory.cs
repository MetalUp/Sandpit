using Antlr4.Runtime.Tree;

namespace SandpitCompiler.AST;

public static class ASTFactory {
    private static T Visit<T>(this SandpitBaseVisitor<ASTNode> visitor, IParseTree pt) where T : ASTNode => (T)visitor.Visit(pt);

    public static ASTNode BuildProcBody(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.ProcBodyContext context) {
        var statNodes = context.stat().Select(visitor.Visit<StatNode>);
        return new BodyNode(statNodes.ToArray());
    }

    public static ASTNode BuildWhileStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.WhileStatContext context) {
        var expr = visitor.Visit<ValueNode>(context.expr());
        var body = visitor.Visit<BodyNode>(context.procBody());

        return new WhileNode(expr, body);
    }

    public static ASTNode BuildStat(this SandpitBaseVisitor<ASTNode> visitor, SandpitParser.StatContext context) => 
        context.varDecl() is { } vd ? visitor.Visit(vd) : visitor.Visit(context.whileStat());
}