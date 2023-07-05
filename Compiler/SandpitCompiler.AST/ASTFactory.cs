using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SandpitCompiler.AST.Node;
using static SandpitParser;

namespace SandpitCompiler.AST;

public static class ASTFactory {
    private static readonly IList<Func<ASTNode, ASTNode>> Rules = new List<Func<ASTNode, ASTNode>>();

    static ASTFactory() {
        Rules.Add(CompilerRules.OnlyOneMainRule);
        Rules.Add(CompilerRules.ExpressionTypeIsBooleanRule);
    }

    private static T Visit<T>(this SandpitBaseVisitor<ASTNode> visitor, IParseTree pt) where T : ASTNode => (T)visitor.Visit(pt);

    private static ASTNode ApplyRules(ASTNode node) => Rules.Aggregate(node, (current, rule) => rule(current));

    public static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParserRuleContext context) =>
        ApplyRules(context switch {
            ArgumentListContext c => visitor.Build(c),
            ArithmeticOpContext c => visitor.Build(c),
            ArrayTypeContext c => visitor.Build(c),
            AssignableValueContext c => visitor.Build(c),
            AssignmentContext c => visitor.Build(c),
            AssignmentOpContext c => visitor.Build(c),
            BinaryOpContext c => visitor.Build(c),
            BoolContext c => visitor.Build(c),
            CaseContext c => visitor.Build(c),
            Case_defaultContext c => visitor.Build(c),
            CharContext c => visitor.Build(c),
            ClassDefContext c => visitor.Build(c),
            ClassNameContext c => visitor.Build(c),
            ConditionalOpContext c => visitor.Build(c),
            ConstantDefContext c => visitor.Build(c),
            ConstantNameContext c => visitor.Build(c),
            ConstructorContext c => visitor.Build(c),
            ControlFlowStatementContext c => visitor.Build(c),
            DataStructureTypeContext c => visitor.Build(c),
            DecimalContext c => visitor.Build(c),
            DictionaryTypeContext c => visitor.Build(c),
            ExpressionContext c => visitor.Build(c),
            ExpressionFunctionContext c => visitor.Build(c),
            FileContext c => visitor.Build(c),
            FloatContext c => visitor.Build(c),
            ForContext c => visitor.Build(c),
            ForInContext c => visitor.Build(c),
            FunctionBlockContext c => visitor.Build(c),
            FunctionCallContext c => visitor.Build(c),
            FunctionDefContext c => visitor.Build(c),
            FunctionMethodContext c => visitor.Build(c),
            FunctionNameContext c => visitor.Build(c),
            FunctionSignatureContext c => visitor.Build(c),
            FunctionWithBodyContext c => visitor.Build(c),
            FuncTypeContext c => visitor.Build(c),
            GenericContext c => visitor.Build(c),
            IfContext c => visitor.Build(c),
            IfExpressionContext c => visitor.Build(c),
            ImmutableClassContext c => visitor.Build(c),
            IndexContext c => visitor.Build(c),
            InstantiationContext c => visitor.Build(c),
            IntegerContext c => visitor.Build(c),
            IterableTypeContext c => visitor.Build(c),
            KvpContext c => visitor.Build(c),
            LambdaContext c => visitor.Build(c),
            LetInContext c => visitor.Build(c),
            LetNameContext c => visitor.Build(c),
            ListDecompContext c => visitor.Build(c),
            ListTypeContext c => visitor.Build(c),
            LiteralValueContext c => visitor.Build(c),
            DataStructureContext c => visitor.Build(c),
            DictionaryContext c => visitor.Build(c),
            ListContext c => visitor.Build(c),
            LogicalOpContext c => visitor.Build(c),
            MainContext c => visitor.Build(c),
            MutableClassContext c => visitor.Build(c),
            ParameterContext c => visitor.Build(c),
            ParameterListContext c => visitor.Build(c),
            ParameterNameContext c => visitor.Build(c),
            ProcedureBlockContext c => visitor.Build(c),
            ProcedureCallContext c => visitor.Build(c),
            ProcedureDefContext c => visitor.Build(c),
            ProcedureMethodContext c => visitor.Build(c),
            ProcedureNameContext c => visitor.Build(c),
            ProcedureSignatureContext c => visitor.Build(c),
            PropertyContext c => visitor.Build(c),
            PropertyNameContext c => visitor.Build(c),
            RangeContext c => visitor.Build(c),
            RepeatContext c => visitor.Build(c),
            StringContext c => visitor.Build(c),
            SwitchContext c => visitor.Build(c),
            SystemCallContext c => visitor.Build(c),
            TryContext c => visitor.Build(c),
            TupleDecompContext c => visitor.Build(c),
            TypeContext c => visitor.Build(c),
            UnaryOpContext c => visitor.Build(c),
            ValueNameContext c => visitor.Build(c),
            ValueReadContext c => visitor.Build(c),
            VarDefContext c => visitor.Build(c),
            VariableNameContext c => visitor.Build(c),
            WhileContext c => visitor.Build(c),
            WithClauseContext c => visitor.Build(c),

            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        });

    public static ASTNode BuildTerminal(this SandpitBaseVisitor<ASTNode> visitor, ITerminalNode node) {
        if (ASTHelpers.MapSymbolToOperator(ASTHelpers.GetTokenName(node.Symbol.Type)) is not Constants.Operators.Unknown) {
            return new OperatorValueNode(node.Symbol);
        }

        if (ASTHelpers.MapSymbolToBuiltInType(ASTHelpers.GetTokenName(node.Symbol.Type)) is not Constants.Types.Unknown) {
            return new BuiltInTypeNode(node.Symbol);
        }

        return new ScalarValueNode(node.Symbol);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArgumentListContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArithmeticOpContext context) {


        return visitor.Visit<OperatorValueNode>(context.children.First());

    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArrayTypeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignableValueContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignmentContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignmentOpContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, BinaryOpContext context) => visitor.Visit<OperatorValueNode>(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, BoolContext context) => visitor.Visit<ValueNode>(context.BOOL_VALUE());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, CaseContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, Case_defaultContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, CharContext context) {
        return visitor.Visit<ValueNode>(context.children.First());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ClassDefContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ClassNameContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConditionalOpContext context) => visitor.Visit(context.children.First());

    private static ConstDefnNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstantDefContext context) => new(visitor.Visit<ValueNode>(context.constantName()), visitor.Visit<ValueNode>(context.expression()));

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstantNameContext context) => visitor.Visit(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstructorContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ControlFlowStatementContext context) => visitor.Visit<StatNode>(context.@while());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DataStructureTypeContext context) {
        return visitor.Visit(context.children.First());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DecimalContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DictionaryTypeContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ExpressionContext context) {
        if (context.ifExpression() is { } ifExpr) {
            return visitor.Visit<ValueNode>(ifExpr);
        }

        if (context.DOT() is { } dot) {
            var fn = visitor.Visit<FunctionCallValueNode>(context.functionCall());
            var p = visitor.Visit<ValueNode>(context.expression().First());
            fn.InsertExtensionParameter(p);
            return fn;
        }

        if (context.functionCall() is { } f) {
            return visitor.Visit<ValueNode>(f);
        }

        if (context.binaryOp() is { } opContext) {
            var e1 = visitor.Visit<ValueNode>(context.expression().First());
            var e2 = visitor.Visit<ValueNode>(context.expression().Last());
            var op = visitor.Visit<OperatorValueNode>(opContext);

            return new BinaryValueNode(op, e1, e2);
        }

        if (context.index() is { } indexContext) {
            var expr = visitor.Visit<ValueNode>(context.expression().First());
            var range = visitor.Visit<ValueNode>(indexContext);

            return new IndexValueNode(expr, range);
        }


        return visitor.Visit(context.valueRead());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ExpressionFunctionContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().functionName());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParamDefnNode>) ?? Array.Empty<ParamDefnNode>();
        var type = visitor.Visit<TypeNode>(context.functionSignature().type());

        var body = new AggregateNode<StatNode>(Array.Empty<StatNode>());

        var expression = visitor.Visit<ValueNode>(context.expression());

        return new FuncDefnNode(id, type, pps.ToArray(), body, expression);
    }

    private static FileNode Build(this SandpitBaseVisitor<ASTNode> visitor, FileContext context) {
        var constNodes = context.constantDef().Select(visitor.Visit<ConstDefnNode>);
        var procNodes = context.procedureDef().Select(visitor.Visit<ProcDefnNode>);
        var funcNodes = context.functionDef().Select(visitor.Visit<FuncDefnNode>);

        var mainNodes = context.main().Select(visitor.Visit<MainNode>);
        return new FileNode(constNodes, procNodes, funcNodes, mainNodes);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FloatContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ForContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ForInContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionBlockContext context) {
        var statNodes = context.children?.Select(visitor.Visit<StatNode>) ?? Array.Empty<StatNode>();
        return new AggregateNode<StatNode>(statNodes);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionCallContext context) {
        var id = visitor.Visit<ValueNode>(context.functionName());
        var pps = context.argumentList().expression().Select(visitor.Visit<ValueNode>);

        return new FunctionCallValueNode(id, pps.ToArray());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionDefContext context) {
        var func = (ParserRuleContext)context.expressionFunction() ?? context.functionWithBody();
        return visitor.Visit(func);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionMethodContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionSignatureContext context) => throw new NotImplementedException();


    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionWithBodyContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().functionName());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParamDefnNode>) ?? Array.Empty<ParamDefnNode>();
        var type = visitor.Visit<TypeNode>(context.functionSignature().type());

        var functionBlock = visitor.Visit<AggregateNode<StatNode>>(context.functionBlock());

        var expression = visitor.Visit<ValueNode>(context.expression());

        return new FuncDefnNode(id, type, pps.ToArray(), functionBlock, expression);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FuncTypeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, GenericContext context) {
        return visitor.Visit<TypeNode>(context.type());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, IfContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, IfExpressionContext context) {
        var ctrl = visitor.Visit<ValueNode>(context.expression()[0]);
        var lhs = visitor.Visit<ValueNode>(context.expression()[1]);
        var rhs = visitor.Visit<ValueNode>(context.expression()[2]);


        return new TernaryValueNode(ctrl, lhs, rhs);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ImmutableClassContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, IndexContext context) {
        if (context.range() is { } rangeContext) {
            return visitor.Visit<ValueNode>(rangeContext);
        }

        return visitor.Visit<ValueNode>(context.expression().First());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, InstantiationContext context) => throw new NotImplementedException();

    private static ValueNode Build(this SandpitBaseVisitor<ASTNode> visitor, IntegerContext context) => visitor.Visit<ValueNode>(context.LITERAL_INTEGER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, IterableTypeContext context) {
        var pt = visitor.Visit<TypeNode>(context.generic());
        var t = visitor.Visit<TypeNode>(context.ITERABLE());

        return new GenericTypeNode(t, pt);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, KvpContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LambdaContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LetInContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LetNameContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ListDecompContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ListTypeContext context) {
        var pt = visitor.Visit<TypeNode>(context.generic());
        var t = visitor.Visit<TypeNode>(context.LIST());

        return new GenericTypeNode(t, pt);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DataStructureContext context) {
        var v = (ParserRuleContext)context.list() ?? context.dictionary();
        return visitor.Visit(v);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DictionaryContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ListContext context) {
        var items = context.expression().Select(visitor.Visit<ValueNode>);

        return new ListValueNode(items.ToArray());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralValueContext context) => visitor.Visit(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LogicalOpContext context) => throw new NotImplementedException();
    private static MainNode Build(this SandpitBaseVisitor<ASTNode> visitor, MainContext context) => new(visitor.Visit<AggregateNode<StatNode>>(context.procedureBlock()));
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, MutableClassContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParameterContext context) {
        var id = visitor.Visit<ValueNode>(context.parameterName());
        var type = visitor.Visit<TypeNode>(context.type());

        return new ParamDefnNode(id, type);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParameterListContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParameterNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static AggregateNode<StatNode> Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureBlockContext context) {
        var statNodes = context.children.Select(visitor.Visit<StatNode>);
        return new AggregateNode<StatNode>(statNodes);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureCallContext context) {
        var id = visitor.Visit<ValueNode>(context.procedureName());
        var pps = context.argumentList()?.expression().Select(visitor.Visit<ValueNode>) ?? Array.Empty<ValueNode>();

        return new ProcStatNode(id, pps.ToArray());
    }

    private static ProcDefnNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureDefContext context) {
        var id = visitor.Visit<ValueNode>(context.procedureSignature().procedureName());
        var pl = context.procedureSignature().parameterList();
        var pps = context.procedureSignature().parameterList()?.parameter().Select(visitor.Visit<ParamDefnNode>) ?? Array.Empty<ParamDefnNode>();
        var procedureBlock = visitor.Visit<AggregateNode<StatNode>>(context.procedureBlock());

        return new ProcDefnNode(id, pps.ToArray(), procedureBlock);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureMethodContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureSignatureContext context) => throw new NotImplementedException();


    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, PropertyContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, PropertyNameContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, RangeContext context) {

        bool prefix = context.children.First() is ITerminalNode;
        var expr1 =  visitor.Visit<ValueNode>(context.children[prefix ? 1 : 0]);
        var expr2 = context.ChildCount == 3 ? visitor.Visit<ValueNode>(context.children[2]) : null;

        return new RangeValueNode(prefix, expr1, expr2);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, RepeatContext context) => throw new NotImplementedException();

   

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, StringContext context) => visitor.Visit<ValueNode>(context.LITERAL_STRING());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SwitchContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SystemCallContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TryContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TupleDecompContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TypeContext context) {
        return visitor.Visit<TypeNode>(context.children.First());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, UnaryOpContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ValueNameContext context) => visitor.Visit(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ValueReadContext context) => visitor.Visit(context.children.First());

    private static VarDefnNode Build(this SandpitBaseVisitor<ASTNode> visitor, VarDefContext context) =>
        new(visitor.Visit<ValueNode>(context.variableName()), visitor.Visit<ValueNode>(context.expression()));

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, VariableNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, WhileContext context) {
        var condition = visitor.Visit<ValueNode>(context.expression());
        var body = visitor.Visit<AggregateNode<StatNode>>(context.procedureBlock());

        return new WhileStatNode(condition, body);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, WithClauseContext context) => throw new NotImplementedException();
}