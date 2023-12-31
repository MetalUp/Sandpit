﻿namespace SandpitCompiler.AST.Symbols;

public class LocalScope : BaseScope {
    public LocalScope(IScope scope) => EnclosingScope = scope;

    public override string ScopeName => "local";
    public override IScope? EnclosingScope { get; }
}