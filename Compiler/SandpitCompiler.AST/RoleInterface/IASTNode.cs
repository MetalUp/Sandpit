namespace SandpitCompiler.AST.RoleInterface;

public interface IASTNode {
    IList<IASTNode> Children { get; }
}