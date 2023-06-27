namespace SandpitCompiler.SymbolTree;

public class GlobalScope : BaseScope {
    public override string ScopeName { get; } = "global";
    public override IScope? EnclosingScope { get; } = null;
}