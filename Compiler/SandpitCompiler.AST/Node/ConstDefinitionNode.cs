using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class ConstDefinitionNode : ASTNode, IDecl {
    public ConstDefinitionNode(ValueNode id, IExpression val) {
        ID = id;
        Val = val;
        SymbolType = val.SymbolType;
        Children = new List<IASTNode> { ID, Val };
    }

    public ValueNode ID { get; }
    public IExpression Val { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Val.ToStringTree()})".TrimEnd();
}