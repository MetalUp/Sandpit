﻿namespace SandpitCompiler.AST.Symbols;

public abstract class BaseScope : IScope {
    private readonly Dictionary<string, ISymbol> symbols = new();

    protected BaseScope() {
       
    }

    public abstract string ScopeName { get; }
    public abstract IScope? EnclosingScope { get; }
    public IEnumerable<IScope> ChildScopes => Symbols.OfType<IScope>();
    public IEnumerable<ISymbol> Symbols => symbols.Values;

    public virtual void Define(ISymbol symbol) {
        symbols[symbol.Name] = symbol;
        symbol.Scope = this;
    }

    public virtual ISymbol? Resolve(string name) => symbols.ContainsKey(name) ? symbols[name] : EnclosingScope?.Resolve(name);

   

    public override string ToString() => string.Join(", ", symbols.Keys);
}