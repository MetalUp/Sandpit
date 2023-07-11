using Antlr4.Runtime;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public  class ValuesNode : ASTNode, IValue {
    public ValueNode[] Values { get; }
    public ValuesNode(ValueNode[] values) {
        Values = values;
        Children = Values.OfType<IASTNode>().ToList();
    }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => throw new NotImplementedException();
}