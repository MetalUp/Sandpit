using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST.RoleInterface;

public interface IProc : IASTNode {
    public ValueNode ID { get; }
}