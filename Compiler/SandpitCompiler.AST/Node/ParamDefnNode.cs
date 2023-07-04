using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class ParamDefnNode : ASTNode, IDecl {
    public ParamDefnNode(ValueNode id, ValueNode type) {
        ID = id;
        Type = type;
        Children = new List<IASTNode> { id, type };
        InferredType = ""; // ASTHelpers.TokenToType(Type.TokenName);
    }

    public string InferredType { get; set; }

    public ValueNode ID { get; }
    public ValueNode Type { get; }

    public string Id => ID.Text;
    public ISymbolType SymbolType => Type is ListValueNode ? new ListType(new BuiltInType(InferredType)) : new BuiltInType(InferredType);

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Type.ToStringTree()})";
}