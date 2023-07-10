using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public abstract class ASTNode : IASTNode {
    public abstract IList<IASTNode> Children { get; }

    public override string ToString() => GetType().Name;

    public abstract string ToStringTree();
}