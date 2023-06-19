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
	/// Visit a parse tree produced by <see cref="SandpitParser.mainDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMainDecl([NotNull] SandpitParser.MainDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.procDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProcDecl([NotNull] SandpitParser.ProcDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.funcDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncDecl([NotNull] SandpitParser.FuncDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.constDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstDecl([NotNull] SandpitParser.ConstDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarDecl([NotNull] SandpitParser.VarDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.letDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLetDecl([NotNull] SandpitParser.LetDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] SandpitParser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] SandpitParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SandpitParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] SandpitParser.TypeContext context);
}
