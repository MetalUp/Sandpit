using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<ASTNode> {
    public override ASTNode VisitChildren(IRuleNode node) => node is ParserRuleContext { } c ? this.Build(c) : base.VisitChildren(node);

    public override ASTNode VisitTerminal(ITerminalNode node) => this.BuildTerminal(node);
}