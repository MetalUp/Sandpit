using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler;

public class ParseTreeVisitor : SandpitBaseVisitor<IASTNode> {
    public override IASTNode VisitChildren(IRuleNode node) => node is ParserRuleContext { } c ? this.Build(c) : base.VisitChildren(node);

    public override IASTNode VisitTerminal(ITerminalNode node) => this.BuildTerminal(node);
}