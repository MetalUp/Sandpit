using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class GenericTypeNode : TypeNode {
    public GenericTypeNode(TypeNode genericType, TypeNode parameterizedType) : base(genericType.Token) => ParameterizedType = parameterizedType;

    public TypeNode ParameterizedType { get; }

    public override IList<IASTNode> Children => new List<IASTNode> { ParameterizedType };
    public override ISymbolType SymbolType => new ListType(ParameterizedType.SymbolType);
    public override string ToStringTree() => throw new NotImplementedException();
}