using SandpitCompiler.AST;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.Symbols;

public class OperatorType : ISymbolType {
    public OperatorType(Constants.Operators op) => Op = op;

    public Constants.Operators Op { get; }
}