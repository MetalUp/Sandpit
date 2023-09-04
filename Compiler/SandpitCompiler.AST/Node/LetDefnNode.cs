﻿using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;

namespace SandpitCompiler.AST.Node;

public class LetDefnNode : ASTNode, IStatement, IExpression {
    public LetDefnNode(AssignmentNode[] values, IExpression returnExpression) {
        Values = values;
        ReturnExpression = returnExpression;
        Children = new List<IASTNode> { returnExpression };
        SymbolType = returnExpression.SymbolType;
    }

    public AssignmentNode[] Values { get; }
    public IExpression ReturnExpression { get; }

    public ISymbolType SymbolType { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {ReturnExpression.ToStringTree()})";
}