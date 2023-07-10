﻿using SandpitCompiler.AST.RoleInterface;

namespace SandpitCompiler.AST.Node;

public class WhileStatNode : StatNode {
    public WhileStatNode(IExpression condition, AggregateNode<StatNode> procedureBlock) {
        Condition = condition;
        ProcedureBlock = procedureBlock.Nodes;
        Children = new List<IASTNode> { condition }.Union(procedureBlock.Nodes).ToList();
    }

    public IList<StatNode> ProcedureBlock { get; }

    public IExpression Condition { get; }

    public override IList<IASTNode> Children { get; }
    public override string ToStringTree() => $"({ToString()} {Condition.ToStringTree()} {ProcedureBlock.AsString()} )";
}