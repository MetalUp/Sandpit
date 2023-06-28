using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public abstract class ASTNode : IASTNode
{
    protected ASTNode() { }

    protected ASTNode(IToken? token) => Token = token;

    public IToken? Token { get; }

    public abstract IList<IASTNode> Children { get; }

    public bool IsNil => Token is null;

    public virtual string Text => Token?.Text ?? "";

    public int TokenType => Token?.Type ?? -1;

    public string TokenName => SandpitParser.DefaultVocabulary.GetSymbolicName(TokenType);

    public override string ToString()
    {
        var typeName = GetType().Name;
        return Token is not null ? $"<{typeName}, '{Token.Text}'>" : typeName;
    }

    public abstract string ToStringTree();
}