using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using static SandpitParser;

namespace SandpitCompiler.AST;

public static class ASTFactory {
    private static T Visit<T>(this SandpitBaseVisitor<IASTNode> visitor, IParseTree pt) where T : IASTNode => (T)visitor.Visit(pt);

    public static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ParserRuleContext context) =>
        context switch {
            ArgumentListContext c => visitor.Build(c),
            ArithmeticOpContext c => visitor.Build(c),
            //ArrayTypeContext c => visitor.Build(c),
            AssignableValueContext c => visitor.Build(c),
            AssignmentContext c => visitor.Build(c),
            AssignmentOpContext c => visitor.Build(c),
            BinaryOpContext c => visitor.Build(c),
            CallStatementContext c => visitor.Build(c),
            CaseContext c => visitor.Build(c),
            ClassDefContext c => visitor.Build(c),
            //ClassNameContext c => visitor.Build(c),
            ConditionalOpContext c => visitor.Build(c),
            ConstantDefContext c => visitor.Build(c),
            //ConstantNameContext c => visitor.Build(c),
            ConstructorContext c => visitor.Build(c),
            DataStructureTypeContext c => visitor.Build(c),
            //DictionaryTypeContext c => visitor.Build(c),
            ExpressionContext c => visitor.Build(c),
            ExpressionFunctionContext c => visitor.Build(c),
            FileContext c => visitor.Build(c),
            ForContext c => visitor.Build(c),
            ForInContext c => visitor.Build(c),
            FunctionDefContext c => visitor.Build(c),
            //FunctionNameContext c => visitor.Build(c),
            FunctionSignatureContext c => visitor.Build(c),
            FunctionWithBodyContext c => visitor.Build(c),
            FuncTypeContext c => visitor.Build(c),
            GenericSpecifierContext c => visitor.Build(c),
            IfContext c => visitor.Build(c),
            IfExpressionContext c => visitor.Build(c),
            ImmutableClassContext c => visitor.Build(c),
            IndexContext c => visitor.Build(c),
            //IterableTypeContext c => visitor.Build(c),
            KvpContext c => visitor.Build(c),
            LambdaContext c => visitor.Build(c),
            LetInContext c => visitor.Build(c),
            //LetNameContext c => visitor.Build(c),
            ListDecompContext c => visitor.Build(c),
            //ListTypeContext c => visitor.Build(c),
            LiteralValueContext c => visitor.Build(c),
            LiteralDataStructureContext c => visitor.Build(c),
            //DictionaryContext c => visitor.Build(c),
            LiteralListContext c => visitor.Build(c),
            LogicalOpContext c => visitor.Build(c),
            MainContext c => visitor.Build(c),
            MethodCallContext c => visitor.Build(c),
            //MethodNameContext c => visitor.Build(c),
            MutableClassContext c => visitor.Build(c),
            ParameterContext c => visitor.Build(c),
            ParameterListContext c => visitor.Build(c),
            //ParameterNameContext c => visitor.Build(c),
            ProceduralControlFlowContext c => visitor.Build(c),
            ProcedureDefContext c => visitor.Build(c),
            //ProcedureNameContext c => visitor.Build(c),
            ProcedureSignatureContext c => visitor.Build(c),
            PropertyContext c => visitor.Build(c),
            //PropertyNameContext c => visitor.Build(c),
            RangeContext c => visitor.Build(c),
            RepeatContext c => visitor.Build(c),
            StatementBlockContext c => visitor.Build(c),
            SwitchContext c => visitor.Build(c),
            TryContext c => visitor.Build(c),
            TupleContext c => visitor.Build(c),
            TupleDecompContext c => visitor.Build(c),
            TupleTypeContext c => visitor.Build(c),
            TypeContext c => visitor.Build(c),
            UnaryOpContext c => visitor.Build(c),
            //ValueNameContext c => visitor.Build(c),
            ValueContext c => visitor.Build(c),
            VarDefContext c => visitor.Build(c),
            //VariableNameContext c => visitor.Build(c),
            WhileContext c => visitor.Build(c),
            WithClauseContext c => visitor.Build(c),

            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        };

    public static IASTNode BuildTerminal(this SandpitBaseVisitor<IASTNode> visitor, ITerminalNode node) {
        if (ASTHelpers.MapSymbolToOperator(ASTHelpers.GetTokenName(node.Symbol.Type)) is not Constants.Operators.Unknown) {
            return new OperatorValueNode(node.Symbol);
        }

        if (ASTHelpers.MapSymbolToBuiltInType(ASTHelpers.GetTokenName(node.Symbol.Type)) is not Constants.Types.Unknown) {
            return new BuiltInTypeNode(node.Symbol);
        }

        return new ScalarValueNode(node.Symbol);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ArgumentListContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ArithmeticOpContext context) => visitor.Visit<OperatorValueNode>(context.children.First());

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ArrayTypeContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, AssignableValueContext context) {
        if (context.tupleDecomp() is { } td) {
            return visitor.Visit(td);
        }

        if (context.listDecomp() is { } ld) {
            return visitor.Visit(ld);
        }

        if (context.index() is { } idx) {
            // indexed value

            throw new NotImplementedException();
        }

        return visitor.Visit(context.IDENTIFIER());
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, AssignmentContext context) {
        var id = visitor.Visit<ValueNode>(context.assignableValue());
        var expr = visitor.Visit<IExpression>(context.expression());

        return new AssignmentNode(id, expr);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, AssignmentOpContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, BinaryOpContext context) => visitor.Visit<OperatorValueNode>(context.children.First());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, CallStatementContext context) => visitor.Visit<IExpression>(context.expression());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, CaseContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ClassDefContext context) => throw new NotImplementedException();
   // private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ClassNameContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ConditionalOpContext context) => visitor.Visit(context.children.First());

    private static ConstDefinitionNode Build(this SandpitBaseVisitor<IASTNode> visitor, ConstantDefContext context) => new(visitor.Visit<ValueNode>(context.IDENTIFIER()), visitor.Visit<IExpression>(context.expression()));

   // private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ConstantNameContext context) => visitor.Visit(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ConstructorContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, DataStructureTypeContext context) {
        return new GenericTypeNode(visitor.Visit<TypeNode>(context.children.First()), visitor.Visit<TypeNode>(context.children.Last()));
    }

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, DictionaryTypeContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ExpressionContext context) {
        if (context.NL() is not null) {
            return visitor.Visit<IExpression>(context.expression().First());
        }

        if (context.binaryOp() is { } opContext) {
            var e1 = visitor.Visit<IExpression>(context.expression().First());
            var e2 = visitor.Visit<IExpression>(context.expression().Last());
            var op = visitor.Visit<OperatorValueNode>(opContext);

            return new BinaryExpressionNode(op, e1, e2);
        }

        if (context.lambda() is { } lambda) {
            return visitor.Visit<IExpression>(lambda);
        }

        if (context.ifExpression() is { } ifExpr) {
            return visitor.Visit<IExpression>(ifExpr);
        }

   

        if (context.value() is { } v) {
            return visitor.Visit<IExpression>(v);
        }

        if (context.index() is { } indexContext) {
            var expr = visitor.Visit<IExpression>(context.expression().First());
            var range = visitor.Visit<IExpression>(indexContext);

            return new IndexedExpressionNode(expr, range);
        }

        if (context.DOT() is { } dot) {
            if (context.methodCall() is { } dmc) {
                var ms = visitor.Visit<MethodStatementNode>(dmc);
                var p = visitor.Visit<IExpression>(context.expression().First());
                return new MethodStatementNode(ms, p);
            }

            if (context.IDENTIFIER() is { } pn) {
                var id = visitor.Visit<ValueNode>(pn);
                var expr = visitor.Visit<IExpression>(context.expression().First());
                return new DereferenceExpressionNode(expr, id);
            }
        }

        if (context.methodCall() is { } mc) {
            return visitor.Visit<IExpression>(mc);
        }

        throw new NotImplementedException();
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ExpressionFunctionContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().IDENTIFIER());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParameterDefinitionNode>) ?? Array.Empty<ParameterDefinitionNode>();
        var type = visitor.Visit<TypeNode>(context.functionSignature().type());

        var body = new AggregateNode<IStatement>(Array.Empty<IStatement>());

        IExpression expression;

        if (context.letIn() is { } letInContext) {
            var avs = letInContext.assignableValue().Select(visitor.Visit<IValue>);
            var exprs = letInContext.expression().Select(visitor.Visit<IExpression>);

            var lets = avs.Zip(exprs).Select(t => new LetVariableDefinitionNode(t.First, t.Second)).ToArray();

            var returnExpr = visitor.Visit<IExpression>(context.expression());

            expression = new LetDefnNode(lets, returnExpr);
        }
        else {
            expression = visitor.Visit<IExpression>(context.expression());
        }

        return new FunctionDefinitionNode(id, type, pps.ToArray(), body, expression);
    }

    private static FileNode Build(this SandpitBaseVisitor<IASTNode> visitor, FileContext context) {
        var constNodes = context.constantDef().Select(visitor.Visit<ConstDefinitionNode>);
        var procNodes = context.procedureDef().Select(visitor.Visit<ProcedureDefinitionNode>);
        var funcNodes = context.functionDef().Select(visitor.Visit<FunctionDefinitionNode>);

        var mainNodes = context.main().Select(visitor.Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes, mainNodes);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ForContext context) => throw new NotImplementedException();
    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ForInContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, FunctionDefContext context) {
        var func = (ParserRuleContext)context.expressionFunction() ?? context.functionWithBody();
        return visitor.Visit(func);
    }

   // private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, FunctionNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, FunctionSignatureContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, FunctionWithBodyContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().IDENTIFIER());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParameterDefinitionNode>) ?? Array.Empty<ParameterDefinitionNode>();
        var type = visitor.Visit<TypeNode>(context.functionSignature().type());

        var functionBlock = visitor.Visit<AggregateNode<IStatement>>(context.statementBlock());

        var expression = visitor.Visit<IExpression>(context.expression());

        return new FunctionDefinitionNode(id, type, pps.ToArray(), functionBlock, expression);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, FuncTypeContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, GenericSpecifierContext context) => visitor.Visit<TypeNode>(context.type().First());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, IfContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, IfExpressionContext context) {
        var ctrl = visitor.Visit<IExpression>(context.expression()[0]);
        var lhs = visitor.Visit<IExpression>(context.expression()[1]);
        var rhs = visitor.Visit<IExpression>(context.expression()[2]);

        return new TernaryExpressionNode(ctrl, lhs, rhs);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ImmutableClassContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, IndexContext context) {
        if (context.range() is { } rangeContext) {
            return visitor.Visit<IExpression>(rangeContext);
        }

        return visitor.Visit<IExpression>(context.expression().First());
    }

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, IterableTypeContext context) {
    //    var pt = visitor.Visit<TypeNode>(context.genericSpecifier());
    //    var t = visitor.Visit<TypeNode>(context.ITERABLE());

    //    return new GenericTypeNode(t, pt);
    //}

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, KvpContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LambdaContext context) {
        var args = context.argumentList().expression().Select(visitor.Visit<ValueNode>);

        return new LambdaExpressionNode(args.ToArray(), visitor.Visit<IExpression>(context.expression()));
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LetInContext context) => throw new NotImplementedException();
   // private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LetNameContext context) => throw new NotImplementedException();
    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ListDecompContext context) => throw new NotImplementedException();

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ListTypeContext context) {
    //    var pt = visitor.Visit<TypeNode>(context.genericSpecifier());
    //    var t = visitor.Visit<TypeNode>(context.LIST());

    //    return new GenericTypeNode(t, pt);
    //}

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LiteralDataStructureContext context) => visitor.Visit(context.children.First());

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, DictionaryContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LiteralListContext context)
    {
        var items = context.expression().Select(visitor.Visit<ValueNode>);

        return new ListExpressionNode(items.ToArray());
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LiteralValueContext context) => visitor.Visit(context.children.First());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, LogicalOpContext context) => visitor.Visit<OperatorValueNode>(context.children.First());

    private static MainNode Build(this SandpitBaseVisitor<IASTNode> visitor, MainContext context) => new(visitor.Visit<AggregateNode<IStatement>>(context.statementBlock()));
    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, MutableClassContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ParameterContext context) {
        var id = visitor.Visit<ValueNode>(context.IDENTIFIER());
        var type = visitor.Visit<TypeNode>(context.type());

        return new ParameterDefinitionNode(id, type);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ParameterListContext context) => throw new NotImplementedException();

   // private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ParameterNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ProceduralControlFlowContext context) => visitor.Visit(context.children.First());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, MethodCallContext context) {
        var id = visitor.Visit<ValueNode>(context.IDENTIFIER());
        var pps = context.argumentList()?.expression().Select(visitor.Visit<IExpression>) ?? Array.Empty<IExpression>();

        return new MethodStatementNode(id, pps.ToArray());
    }

    private static ProcedureDefinitionNode Build(this SandpitBaseVisitor<IASTNode> visitor, ProcedureDefContext context) {
        var id = visitor.Visit<ValueNode>(context.procedureSignature().IDENTIFIER());
        var pl = context.procedureSignature().parameterList();
        var pps = context.procedureSignature().parameterList()?.parameter().Select(visitor.Visit<ParameterDefinitionNode>) ?? Array.Empty<ParameterDefinitionNode>();
        var procedureBlock = visitor.Visit<AggregateNode<IStatement>>(context.statementBlock());

        return new ProcedureDefinitionNode(id, pps.ToArray(), procedureBlock);
    }

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ProcedureNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ProcedureSignatureContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, PropertyContext context) => throw new NotImplementedException();

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, PropertyNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, RangeContext context) {
        var prefix = context.children.First() is ITerminalNode;
        var expr1 = visitor.Visit<IExpression>(context.children[prefix ? 1 : 0]);
        var expr2 = context.ChildCount == 3 ? visitor.Visit<IExpression>(context.children[2]) : null;

        return new RangeExpressionNode(prefix, expr1, expr2);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, RepeatContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, SwitchContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, TryContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, TupleContext context) {
        var items = context.expression().Select(visitor.Visit<IExpression>);

        return new TupleExpressionNode(items.ToArray());
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, TupleDecompContext context) => new ValuesNode(context.IDENTIFIER().Select(visitor.Visit<ValueNode>).ToArray());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, TupleTypeContext context) => new TupleTypeNode(context.type().Select(visitor.Visit<TypeNode>));

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, TypeContext context) {
        if (context.VALUE_TYPE() is {} vt) {
            return visitor.Visit<TypeNode>(vt);
        }

        if (context.TYPENAME() is {} tn) {
            return visitor.Visit<TypeNode>(tn);
        }

        if (context.dataStructureType() is {} dt)
        {
            return visitor.Visit<TypeNode>(dt);
        }

        if (context.funcType() is {} ft)
        {
            return visitor.Visit<TypeNode>(ft);
        }

        if (context.tupleType() is {} tt)
        {
            return visitor.Visit<TypeNode>(tt);
        }

        throw new NotImplementedException();

        //return visitor.Visit<TypeNode>(context.children.First());
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, UnaryOpContext context) => throw new NotImplementedException();

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ValueNameContext context) => visitor.Visit(context.children.First());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, ValueContext context) => visitor.Visit(context.children.First());

    private static VarDefinitionNode Build(this SandpitBaseVisitor<IASTNode> visitor, VarDefContext context) =>
        new(visitor.Visit<ValueNode>(context.IDENTIFIER()), visitor.Visit<IExpression>(context.expression()));

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, VariableNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, WhileContext context) {
        var condition = visitor.Visit<IExpression>(context.expression());
        var body = visitor.Visit<AggregateNode<IStatement>>(context.statementBlock());

        return new WhileStatementNode(condition, body);
    }

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, WithClauseContext context) => throw new NotImplementedException();

    private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, StatementBlockContext context) {
        var statNodes = context.children?.Select(visitor.Visit<IStatement>) ?? Array.Empty<IStatement>();
        return new AggregateNode<IStatement>(statNodes);
    }

    //private static IASTNode Build(this SandpitBaseVisitor<IASTNode> visitor, MethodNameContext context) {
    //    if (context.functionName() is { } fn) {
    //        return visitor.Visit(fn);
    //    }

    //    return visitor.Visit(context.procedureName());
    //}
}