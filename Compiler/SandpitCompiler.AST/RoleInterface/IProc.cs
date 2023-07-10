using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.RoleInterface;

public interface IProc : IASTNode {
    public ValueNode ID { get; }

    public ISymbolType? SymbolType { get; }
}