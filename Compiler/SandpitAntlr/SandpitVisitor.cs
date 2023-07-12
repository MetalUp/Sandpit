//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\GitHub\Sandpit\Compiler\SandpitAntlr\Sandpit.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SandpitParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface ISandpitVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFile([NotNull] SandpitParser.FileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] SandpitParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.constantDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantDef([NotNull] SandpitParser.ConstantDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.classDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassDef([NotNull] SandpitParser.ClassDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.mutableClass"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMutableClass([NotNull] SandpitParser.MutableClassContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.immutableClass"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImmutableClass([NotNull] SandpitParser.ImmutableClassContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.abstractClass"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbstractClass([NotNull] SandpitParser.AbstractClassContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.inherits"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInherits([NotNull] SandpitParser.InheritsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.constructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstructor([NotNull] SandpitParser.ConstructorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProperty([NotNull] SandpitParser.PropertyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDef([NotNull] SandpitParser.FunctionDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionWithBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionWithBody([NotNull] SandpitParser.FunctionWithBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.expressionFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionFunction([NotNull] SandpitParser.ExpressionFunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionSignature"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionSignature([NotNull] SandpitParser.FunctionSignatureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procedureDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcedureDef([NotNull] SandpitParser.ProcedureDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procedureSignature"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcedureSignature([NotNull] SandpitParser.ProcedureSignatureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procedureBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcedureBlock([NotNull] SandpitParser.ProcedureBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionBlock([NotNull] SandpitParser.FunctionBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.varDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarDef([NotNull] SandpitParser.VarDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] SandpitParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.systemCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSystemCall([NotNull] SandpitParser.SystemCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.systemIn"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSystemIn([NotNull] SandpitParser.SystemInContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.systemOut"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSystemOut([NotNull] SandpitParser.SystemOutContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.print"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint([NotNull] SandpitParser.PrintContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.printLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintLine([NotNull] SandpitParser.PrintLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] SandpitParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.openRead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOpenRead([NotNull] SandpitParser.OpenReadContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.openWrite"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOpenWrite([NotNull] SandpitParser.OpenWriteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.readLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReadLine([NotNull] SandpitParser.ReadLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.writeLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWriteLine([NotNull] SandpitParser.WriteLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.endOfFile"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEndOfFile([NotNull] SandpitParser.EndOfFileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.closeFile"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCloseFile([NotNull] SandpitParser.CloseFileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.today"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitToday([NotNull] SandpitParser.TodayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.now"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNow([NotNull] SandpitParser.NowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.newRandom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewRandom([NotNull] SandpitParser.NewRandomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.randomNext"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRandomNext([NotNull] SandpitParser.RandomNextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.assignableValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignableValue([NotNull] SandpitParser.AssignableValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procedureCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcedureCall([NotNull] SandpitParser.ProcedureCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] SandpitParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentList([NotNull] SandpitParser.ArgumentListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] SandpitParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] SandpitParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.proceduralControlFlow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProceduralControlFlow([NotNull] SandpitParser.ProceduralControlFlowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionalControlFlow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionalControlFlow([NotNull] SandpitParser.FunctionalControlFlowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf([NotNull] SandpitParser.IfContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.if_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_functional([NotNull] SandpitParser.If_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.for"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFor([NotNull] SandpitParser.ForContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.for_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFor_functional([NotNull] SandpitParser.For_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.forIn"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForIn([NotNull] SandpitParser.ForInContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.forIn_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForIn_functional([NotNull] SandpitParser.ForIn_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.while"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile([NotNull] SandpitParser.WhileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.while_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile_functional([NotNull] SandpitParser.While_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeat([NotNull] SandpitParser.RepeatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.repeat_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeat_functional([NotNull] SandpitParser.Repeat_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.try"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTry([NotNull] SandpitParser.TryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.try_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTry_functional([NotNull] SandpitParser.Try_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.switch"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitch([NotNull] SandpitParser.SwitchContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.switch_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitch_functional([NotNull] SandpitParser.Switch_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.case"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCase([NotNull] SandpitParser.CaseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.case_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCase_functional([NotNull] SandpitParser.Case_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.caseDefault"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseDefault([NotNull] SandpitParser.CaseDefaultContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.caseDefault_functional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseDefault_functional([NotNull] SandpitParser.CaseDefault_functionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] SandpitParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.ifExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfExpression([NotNull] SandpitParser.IfExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.lambda"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLambda([NotNull] SandpitParser.LambdaContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.letIn"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLetIn([NotNull] SandpitParser.LetInContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.index"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndex([NotNull] SandpitParser.IndexContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRange([NotNull] SandpitParser.RangeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] SandpitParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.dataStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDataStructure([NotNull] SandpitParser.DataStructureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.tuple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTuple([NotNull] SandpitParser.TupleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.tupleDecomp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTupleDecomp([NotNull] SandpitParser.TupleDecompContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList([NotNull] SandpitParser.ListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.listDecomp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListDecomp([NotNull] SandpitParser.ListDecompContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.dictionary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDictionary([NotNull] SandpitParser.DictionaryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.kvp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKvp([NotNull] SandpitParser.KvpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.assignmentOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentOp([NotNull] SandpitParser.AssignmentOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.unaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryOp([NotNull] SandpitParser.UnaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.binaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryOp([NotNull] SandpitParser.BinaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.arithmeticOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArithmeticOp([NotNull] SandpitParser.ArithmeticOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.logicalOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOp([NotNull] SandpitParser.LogicalOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.conditionalOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalOp([NotNull] SandpitParser.ConditionalOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.literalValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralValue([NotNull] SandpitParser.LiteralValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.newInstance"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewInstance([NotNull] SandpitParser.NewInstanceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.withClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWithClause([NotNull] SandpitParser.WithClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] SandpitParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.enumeration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumeration([NotNull] SandpitParser.EnumerationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumValue([NotNull] SandpitParser.EnumValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.dataStructureType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDataStructureType([NotNull] SandpitParser.DataStructureTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.tupleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTupleType([NotNull] SandpitParser.TupleTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.arrayType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayType([NotNull] SandpitParser.ArrayTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.listType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListType([NotNull] SandpitParser.ListTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.dictionaryType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDictionaryType([NotNull] SandpitParser.DictionaryTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.iterableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterableType([NotNull] SandpitParser.IterableTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.genericType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGenericType([NotNull] SandpitParser.GenericTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.generic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGeneric([NotNull] SandpitParser.GenericContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.funcType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncType([NotNull] SandpitParser.FuncTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.className"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassName([NotNull] SandpitParser.ClassNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.valueName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValueName([NotNull] SandpitParser.ValueNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.constantName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantName([NotNull] SandpitParser.ConstantNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.propertyName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPropertyName([NotNull] SandpitParser.PropertyNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.parameterName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterName([NotNull] SandpitParser.ParameterNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.variableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableName([NotNull] SandpitParser.VariableNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.letName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLetName([NotNull] SandpitParser.LetNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procedureName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcedureName([NotNull] SandpitParser.ProcedureNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionName([NotNull] SandpitParser.FunctionNameContext context);
}
