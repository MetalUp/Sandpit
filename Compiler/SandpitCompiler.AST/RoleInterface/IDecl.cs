using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST.RoleInterface;

public interface IDecl : IASTNode {
    public ValueNode ID { get; }
}