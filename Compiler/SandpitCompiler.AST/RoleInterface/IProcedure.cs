using SandpitCompiler.AST.Node;

namespace SandpitCompiler.AST.RoleInterface;

public interface IProcedure : IASTNode {
    public ValueNode ID { get; }
}