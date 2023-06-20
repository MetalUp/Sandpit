using Antlr4.Runtime;

namespace SandpitCompiler.AST;

public abstract class ASTNode {
    protected ASTNode() { }

    protected ASTNode(IToken token) => Token = token;

    private IToken? Token { get; }

    public IList<ASTNode> Children { get; set; } = new List<ASTNode>();

    public bool IsNil => Token is null;

    public string Text => Token?.Text ?? "";

    public int TokenType => Token?.Type ?? -1;

    public string TokenName => SandpitParser.DefaultVocabulary.GetSymbolicName(TokenType);

    public override string ToString() {
        var typeName = GetType().Name;
        return Token is not null ? $"<{typeName}, '{Token.Text}'>" : typeName;
    }

    public abstract string ToStringTree();
}