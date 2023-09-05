using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public abstract class ValueNode : ASTNode, IExpression, IValue {
    protected ValueNode(IToken? token) => Token = token;

    public IToken? Token { get; }

    public int TokenType => Token?.Type ?? -1;

    public string TokenName => ASTHelpers.GetTokenName(TokenType);

    public abstract ISymbolType SymbolType { get; }

    public override string ToStringTree() => ToString();

    public virtual string Text => Token?.Text ?? "";

    public override string ToString() {
        var typeName = GetType().Name;
        return $"<{typeName}, '{Token?.Text}'>";
    }
}