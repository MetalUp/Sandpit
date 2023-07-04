using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public abstract class TypeNode : ASTNode {
    protected TypeNode(IToken? nodeSymbol) : base(nodeSymbol) { }

}