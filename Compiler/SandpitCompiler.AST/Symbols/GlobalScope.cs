namespace SandpitCompiler.AST.Symbols;

public class GlobalScope : BaseScope {
    public override string ScopeName { get; } = "global";
    public override IScope? EnclosingScope { get; } = null;
}