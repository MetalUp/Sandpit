using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class ParameterDefinitionNode : ASTNode, IDecl {
    public ParameterDefinitionNode(ValueNode id, TypeNode type) {
        ID = id;
        Type = type;
        Children = new List<IASTNode> { id, type };
    }

    public ValueNode ID { get; }
    public TypeNode Type { get; }

    public string Id => ID.Text;
    public ISymbolType SymbolType => Type.SymbolType;

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Type.ToStringTree()})";
}