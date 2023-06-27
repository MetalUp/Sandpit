using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public abstract class ASTNode {
    protected ASTNode() { }

    protected ASTNode(IToken? token) => Token = token;

    public IToken? Token { get; }

    public abstract IList<ASTNode> Children { get; }

    public bool IsNil => Token is null;

    public virtual string Text => Token?.Text ?? "";

    public int TokenType => Token?.Type ?? -1;

    public string TokenName => SandpitParser.DefaultVocabulary.GetSymbolicName(TokenType);

    public override string ToString() {
        var typeName = GetType().Name;
        return Token is not null ? $"<{typeName}, '{Token.Text}'>" : typeName;
    }

    public abstract string ToStringTree();
}