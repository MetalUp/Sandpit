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
            FunctionStatementContext c => visitor.Build(c),
            FunctionWithBodyContext c => visitor.Build(c),
            FuncTypeContext c => visitor.Build(c),
            GenericContext c => visitor.Build(c),
            IfContext c => visitor.Build(c),
            ImmutableClassContext c => visitor.Build(c),
            InstantiationContext c => visitor.Build(c),
            IntegerContext c => visitor.Build(c),
            KvpContext c => visitor.Build(c),
            LambdaContext c => visitor.Build(c),
            LetInContext c => visitor.Build(c),
            LetNameContext c => visitor.Build(c),
            ListDecompContext c => visitor.Build(c),
            ListTypeContext c => visitor.Build(c),
            LiteralContext c => visitor.Build(c),
            LiteralDataStructureContext c => visitor.Build(c),
            LiteralDictionaryContext c => visitor.Build(c),
            LiteralListContext c => visitor.Build(c),
            LiteralValueContext c => visitor.Build(c),
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
            ProcedureStatementContext c => visitor.Build(c),
            PropertyContext c => visitor.Build(c),
            PropertyNameContext c => visitor.Build(c),
            RangeContext c => visitor.Build(c),
            RepeatContext c => visitor.Build(c),
            SimpleExpressionContext c => visitor.Build(c),
            SliceOfListContext c => visitor.Build(c),
            StringContext c => visitor.Build(c),
            SwitchContext c => visitor.Build(c),
            SystemCallContext c => visitor.Build(c),
            TryContext c => visitor.Build(c),
            TupleDecompContext c => visitor.Build(c),
            TypeContext c => visitor.Build(c),
            UnaryOpContext c => visitor.Build(c),
            ValueNameContext c => visitor.Build(c),
            VarDefContext c => visitor.Build(c),
            VariableNameContext c => visitor.Build(c),
            WhileContext c => visitor.Build(c),
            WithClauseContext c => visitor.Build(c),

            _ => throw new NotImplementedException(context?.GetType().FullName ?? null)
        });

    public static ValueNode BuildTerminal(this SandpitBaseVisitor<ASTNode> visitor, ITerminalNode node) {
        if (ASTHelpers.MapSymbolToOperator(ASTHelpers.GetTokenName(node.Symbol.Type)) is not Constants.Operators.Unknown) {
            return new OperatorValueNode(node.Symbol);
        }

        return new ScalarValueNode(node.Symbol);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArgumentListContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArithmeticOpContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ArrayTypeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignableValueContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignmentContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, AssignmentOpContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, BinaryOpContext context) => visitor.Visit<OperatorValueNode>(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, BoolContext context) => visitor.Visit<ValueNode>(context.BOOL());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, CaseContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, Case_defaultContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, CharContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ClassDefContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ClassNameContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConditionalOpContext context) => visitor.Visit(context.children.First());

    private static ConstDefnNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstantDefContext context) => new(visitor.Visit<ValueNode>(context.constantName()), visitor.Visit<ValueNode>(context.expression()));

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstantNameContext context) => visitor.Visit(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ConstructorContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ControlFlowStatementContext context) => visitor.Visit<StatNode>(context.@while());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DataStructureTypeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DecimalContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, DictionaryTypeContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ExpressionContext context) {
        if (context.binaryOp() is { } opContext) {
            var e1 = visitor.Visit<ValueNode>(context.expression().First());
            var e2 = visitor.Visit<ValueNode>(context.expression().Last());
            var op = visitor.Visit<OperatorValueNode>(opContext);

            return new BinaryValueNode(op, e1, e2);
        }

        return visitor.Visit(context.simpleExpression());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ExpressionFunctionContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().functionName());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParamDefnNode>) ?? Array.Empty<ParamDefnNode>();
        var type = visitor.Visit<ValueNode>(context.functionSignature().type());

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

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionCallContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionDefContext context) {
        var func = (ParserRuleContext)context.expressionFunction() ?? context.functionWithBody();
        return visitor.Visit(func);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionMethodContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionNameContext context) => visitor.Visit<ValueNode>(context.IDENTIFIER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionSignatureContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionStatementContext context) {
        var n = (ParserRuleContext)context.children.First();
        return visitor.Visit<StatNode>(n);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FunctionWithBodyContext context) {
        var id = visitor.Visit<ValueNode>(context.functionSignature().functionName());
        var pps = context.functionSignature().parameterList()?.parameter().Select(visitor.Visit<ParamDefnNode>) ?? Array.Empty<ParamDefnNode>();
        var type = visitor.Visit<ValueNode>(context.functionSignature().type());

        var functionBlock = visitor.Visit<AggregateNode<StatNode>>(context.functionBlock());

        var expression = visitor.Visit<ValueNode>(context.expression());

        return new FuncDefnNode(id, type, pps.ToArray(), functionBlock, expression);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, FuncTypeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, GenericContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, IfContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ImmutableClassContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, InstantiationContext context) => throw new NotImplementedException();

    private static ValueNode Build(this SandpitBaseVisitor<ASTNode> visitor, IntegerContext context) => visitor.Visit<ValueNode>(context.LITERAL_INTEGER());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, KvpContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LambdaContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LetInContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LetNameContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ListDecompContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ListTypeContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralContext context) {
        var v = (ParserRuleContext)context.literalValue() ?? context.literalDataStructure();
        return visitor.Visit(v);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralDataStructureContext context) {
        var v = (ParserRuleContext)context.literalList() ?? context.literalDictionary();
        return visitor.Visit(v);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralDictionaryContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralListContext context) {
        var items = context.literal().Select(visitor.Visit<ValueNode>);

        return new ListValueNode(items.ToArray());
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LiteralValueContext context) => visitor.Visit(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, LogicalOpContext context) => throw new NotImplementedException();
    private static MainNode Build(this SandpitBaseVisitor<ASTNode> visitor, MainContext context) => new(visitor.Visit<AggregateNode<StatNode>>(context.procedureBlock()));
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, MutableClassContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ParameterContext context) {
        var id = visitor.Visit<ValueNode>(context.parameterName());
        var type = visitor.Visit<ValueNode>(context.type());

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

    private static StatNode Build(this SandpitBaseVisitor<ASTNode> visitor, ProcedureStatementContext context) {
        var n = (ParserRuleContext)context.children.First();
        return visitor.Visit<StatNode>(n);
    }

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, PropertyContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, PropertyNameContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, RangeContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, RepeatContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SimpleExpressionContext context) => visitor.Visit(context.children.First());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SliceOfListContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, StringContext context) => visitor.Visit<ValueNode>(context.LITERAL_STRING());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SwitchContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, SystemCallContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TryContext context) => throw new NotImplementedException();
    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TupleDecompContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, TypeContext context) => visitor.Visit<ValueNode>(context.VALUE_TYPE());

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, UnaryOpContext context) => throw new NotImplementedException();

    private static ASTNode Build(this SandpitBaseVisitor<ASTNode> visitor, ValueNameContext context) => visitor.Visit(context.children.First());

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