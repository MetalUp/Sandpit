using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Symbols;

namespace SandpitCompiler.AST.Node;

public class ConstDefnNode : ASTNode, IDecl {
    public ConstDefnNode(ValueNode id, ValueNode val) {
        ID = id;
        Val = val;
        //SymbolType = ASTHelpers.TokenToType(val.Token ?? throw new ArgumentNullException());
        SymbolType = val.SymbolType;
        Children = new List<IASTNode> { ID, Val };
    }

    public ValueNode ID { get; }
    public ValueNode Val { get; }
    public string Id => ID.Text;
    public ISymbolType SymbolType { get; }
    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ID.ToStringTree()}{Val.ToStringTree()})".TrimEnd();
}