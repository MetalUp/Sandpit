using Microsoft.VisualBasic;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Symbols;

public interface IUnresolvedType : ISymbolType {
    public ISymbolType Resolve(IScope scope, int depth = 0);

    public const int MaxDepth = 10;
}