using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.RoleInterface;

public interface IProcedure : IASTNode {
    public ValueNode ID { get; }
}