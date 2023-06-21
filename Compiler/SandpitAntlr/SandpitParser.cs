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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class SandpitParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, ID=22, INT=23, STRING=24, NEWLINE=25, 
		WS=26;
	public const int
		RULE_file = 0, RULE_mainDecl = 1, RULE_procDecl = 2, RULE_funcDecl = 3, 
		RULE_constDecl = 4, RULE_varDecl = 5, RULE_letDecl = 6, RULE_whileStat = 7, 
		RULE_param = 8, RULE_constVal = 9, RULE_expr = 10, RULE_type = 11, RULE_procBody = 12, 
		RULE_funcBody = 13;
	public static readonly string[] ruleNames = {
		"file", "mainDecl", "procDecl", "funcDecl", "constDecl", "varDecl", "letDecl", 
		"whileStat", "param", "constVal", "expr", "type", "procBody", "funcBody"
	};

	private static readonly string[] _LiteralNames = {
		null, "'main'", "'end main'", "'procedure'", "'('", "')'", "'end procedure'", 
		"'function'", "':'", "'end function'", "'constant'", "'='", "'var'", "'let'", 
		"'while'", "'end while'", "'{'", "','", "'}'", "'Integer'", "'String'", 
		"'return'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, "ID", "INT", 
		"STRING", "NEWLINE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Sandpit.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SandpitParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SandpitParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SandpitParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class FileContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ConstDeclContext[] constDecl() {
			return GetRuleContexts<ConstDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ConstDeclContext constDecl(int i) {
			return GetRuleContext<ConstDeclContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ProcDeclContext[] procDecl() {
			return GetRuleContexts<ProcDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ProcDeclContext procDecl(int i) {
			return GetRuleContext<ProcDeclContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public FuncDeclContext[] funcDecl() {
			return GetRuleContexts<FuncDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public FuncDeclContext funcDecl(int i) {
			return GetRuleContext<FuncDeclContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MainDeclContext[] mainDecl() {
			return GetRuleContexts<MainDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public MainDeclContext mainDecl(int i) {
			return GetRuleContext<MainDeclContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(SandpitParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(SandpitParser.NEWLINE, i);
		}
		public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_file; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFile(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 35;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__2) | (1L << T__6) | (1L << T__9) | (1L << NEWLINE))) != 0)) {
				{
				State = 33;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case T__9:
					{
					State = 28;
					constDecl();
					}
					break;
				case T__2:
					{
					State = 29;
					procDecl();
					}
					break;
				case T__6:
					{
					State = 30;
					funcDecl();
					}
					break;
				case T__0:
					{
					State = 31;
					mainDecl();
					}
					break;
				case NEWLINE:
					{
					State = 32;
					Match(NEWLINE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 37;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MainDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(SandpitParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(SandpitParser.NEWLINE, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ProcBodyContext procBody() {
			return GetRuleContext<ProcBodyContext>(0);
		}
		public MainDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_mainDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMainDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MainDeclContext mainDecl() {
		MainDeclContext _localctx = new MainDeclContext(Context, State);
		EnterRule(_localctx, 2, RULE_mainDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 38;
			Match(T__0);
			State = 39;
			Match(NEWLINE);
			State = 40;
			procBody();
			State = 41;
			Match(T__1);
			State = 42;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ProcDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(SandpitParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(SandpitParser.NEWLINE, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ProcBodyContext procBody() {
			return GetRuleContext<ProcBodyContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ParamContext[] param() {
			return GetRuleContexts<ParamContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ParamContext param(int i) {
			return GetRuleContext<ParamContext>(i);
		}
		public ProcDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_procDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProcDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProcDeclContext procDecl() {
		ProcDeclContext _localctx = new ProcDeclContext(Context, State);
		EnterRule(_localctx, 4, RULE_procDecl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			Match(T__2);
			State = 45;
			Match(ID);
			State = 46;
			Match(T__3);
			State = 50;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==ID) {
				{
				{
				State = 47;
				param();
				}
				}
				State = 52;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 53;
			Match(T__4);
			State = 54;
			Match(NEWLINE);
			State = 55;
			procBody();
			State = 56;
			Match(T__5);
			State = 57;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(SandpitParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(SandpitParser.NEWLINE, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public FuncBodyContext funcBody() {
			return GetRuleContext<FuncBodyContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ParamContext[] param() {
			return GetRuleContexts<ParamContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ParamContext param(int i) {
			return GetRuleContext<ParamContext>(i);
		}
		public FuncDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_funcDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncDeclContext funcDecl() {
		FuncDeclContext _localctx = new FuncDeclContext(Context, State);
		EnterRule(_localctx, 6, RULE_funcDecl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 59;
			Match(T__6);
			State = 60;
			Match(ID);
			State = 61;
			Match(T__3);
			State = 65;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==ID) {
				{
				{
				State = 62;
				param();
				}
				}
				State = 67;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 68;
			Match(T__4);
			State = 69;
			Match(T__7);
			State = 70;
			type();
			State = 71;
			Match(NEWLINE);
			State = 72;
			funcBody();
			State = 73;
			Match(T__8);
			State = 74;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConstDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ConstValContext constVal() {
			return GetRuleContext<ConstValContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(SandpitParser.NEWLINE, 0); }
		public ConstDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_constDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConstDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ConstDeclContext constDecl() {
		ConstDeclContext _localctx = new ConstDeclContext(Context, State);
		EnterRule(_localctx, 8, RULE_constDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 76;
			Match(T__9);
			State = 77;
			Match(ID);
			State = 78;
			Match(T__10);
			State = 79;
			constVal();
			State = 80;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(SandpitParser.NEWLINE, 0); }
		public VarDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_varDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDeclContext varDecl() {
		VarDeclContext _localctx = new VarDeclContext(Context, State);
		EnterRule(_localctx, 10, RULE_varDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			Match(T__11);
			State = 83;
			Match(ID);
			State = 84;
			Match(T__10);
			State = 85;
			expr();
			State = 86;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LetDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(SandpitParser.NEWLINE, 0); }
		public LetDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_letDecl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLetDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LetDeclContext letDecl() {
		LetDeclContext _localctx = new LetDeclContext(Context, State);
		EnterRule(_localctx, 12, RULE_letDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 88;
			Match(T__12);
			State = 89;
			Match(ID);
			State = 90;
			Match(T__10);
			State = 91;
			expr();
			State = 92;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class WhileStatContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] NEWLINE() { return GetTokens(SandpitParser.NEWLINE); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE(int i) {
			return GetToken(SandpitParser.NEWLINE, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ProcBodyContext procBody() {
			return GetRuleContext<ProcBodyContext>(0);
		}
		public WhileStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_whileStat; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitWhileStat(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public WhileStatContext whileStat() {
		WhileStatContext _localctx = new WhileStatContext(Context, State);
		EnterRule(_localctx, 14, RULE_whileStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 94;
			Match(T__13);
			State = 95;
			expr();
			State = 96;
			Match(NEWLINE);
			State = 97;
			procBody();
			State = 98;
			Match(NEWLINE);
			State = 99;
			Match(T__14);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ParamContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public ParamContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_param; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParam(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ParamContext param() {
		ParamContext _localctx = new ParamContext(Context, State);
		EnterRule(_localctx, 16, RULE_param);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 101;
			Match(ID);
			State = 102;
			Match(T__7);
			State = 103;
			type();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConstValContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(SandpitParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(SandpitParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ConstValContext[] constVal() {
			return GetRuleContexts<ConstValContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ConstValContext constVal(int i) {
			return GetRuleContext<ConstValContext>(i);
		}
		public ConstValContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_constVal; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConstVal(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ConstValContext constVal() {
		ConstValContext _localctx = new ConstValContext(Context, State);
		EnterRule(_localctx, 18, RULE_constVal);
		int _la;
		try {
			State = 119;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				EnterOuterAlt(_localctx, 1);
				{
				State = 105;
				Match(INT);
				}
				break;
			case STRING:
				EnterOuterAlt(_localctx, 2);
				{
				State = 106;
				Match(STRING);
				}
				break;
			case T__15:
				EnterOuterAlt(_localctx, 3);
				{
				State = 107;
				Match(T__15);
				State = 109;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__15) | (1L << INT) | (1L << STRING))) != 0)) {
					{
					State = 108;
					constVal();
					}
				}

				State = 115;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__16) {
					{
					{
					State = 111;
					Match(T__16);
					State = 112;
					constVal();
					}
					}
					State = 117;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 118;
				Match(T__17);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ConstValContext constVal() {
			return GetRuleContext<ConstValContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(Context, State);
		EnterRule(_localctx, 20, RULE_expr);
		try {
			State = 123;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__15:
			case INT:
			case STRING:
				EnterOuterAlt(_localctx, 1);
				{
				State = 121;
				constVal();
				}
				break;
			case ID:
				EnterOuterAlt(_localctx, 2);
				{
				State = 122;
				Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 22, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 125;
			_la = TokenStream.LA(1);
			if ( !(_la==T__18 || _la==T__19) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ProcBodyContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext[] varDecl() {
			return GetRuleContexts<VarDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext varDecl(int i) {
			return GetRuleContext<VarDeclContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public WhileStatContext[] whileStat() {
			return GetRuleContexts<WhileStatContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public WhileStatContext whileStat(int i) {
			return GetRuleContext<WhileStatContext>(i);
		}
		public ProcBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_procBody; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProcBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProcBodyContext procBody() {
		ProcBodyContext _localctx = new ProcBodyContext(Context, State);
		EnterRule(_localctx, 24, RULE_procBody);
		int _la;
		try {
			State = 138;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__11:
				EnterOuterAlt(_localctx, 1);
				{
				State = 128;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 127;
					varDecl();
					}
					}
					State = 130;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( _la==T__11 );
				}
				break;
			case T__1:
			case T__5:
			case T__13:
			case NEWLINE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 135;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__13) {
					{
					{
					State = 132;
					whileStat();
					}
					}
					State = 137;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncBodyContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(SandpitParser.NEWLINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public LetDeclContext[] letDecl() {
			return GetRuleContexts<LetDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public LetDeclContext letDecl(int i) {
			return GetRuleContext<LetDeclContext>(i);
		}
		public FuncBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_funcBody; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISandpitVisitor<TResult> typedVisitor = visitor as ISandpitVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncBodyContext funcBody() {
		FuncBodyContext _localctx = new FuncBodyContext(Context, State);
		EnterRule(_localctx, 26, RULE_funcBody);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 143;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__12) {
				{
				{
				State = 140;
				letDecl();
				}
				}
				State = 145;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 146;
			Match(T__20);
			State = 147;
			expr();
			State = 148;
			Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x1C', '\x99', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', '\t', 
		'\xE', '\x4', '\xF', '\t', '\xF', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\a', '\x2', '$', '\n', '\x2', '\f', '\x2', 
		'\xE', '\x2', '\'', '\v', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\a', '\x4', '\x33', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', '\x36', '\v', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', '\x42', '\n', '\x5', '\f', 
		'\x5', '\xE', '\x5', '\x45', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', 
		'\v', '\x3', '\v', '\x5', '\v', 'p', '\n', '\v', '\x3', '\v', '\x3', '\v', 
		'\a', '\v', 't', '\n', '\v', '\f', '\v', '\xE', '\v', 'w', '\v', '\v', 
		'\x3', '\v', '\x5', '\v', 'z', '\n', '\v', '\x3', '\f', '\x3', '\f', '\x5', 
		'\f', '~', '\n', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x6', 
		'\xE', '\x83', '\n', '\xE', '\r', '\xE', '\xE', '\xE', '\x84', '\x3', 
		'\xE', '\a', '\xE', '\x88', '\n', '\xE', '\f', '\xE', '\xE', '\xE', '\x8B', 
		'\v', '\xE', '\x5', '\xE', '\x8D', '\n', '\xE', '\x3', '\xF', '\a', '\xF', 
		'\x90', '\n', '\xF', '\f', '\xF', '\xE', '\xF', '\x93', '\v', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x2', 
		'\x2', '\x10', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', '\x10', '\x12', 
		'\x14', '\x16', '\x18', '\x1A', '\x1C', '\x2', '\x3', '\x3', '\x2', '\x15', 
		'\x16', '\x2', '\x9A', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x4', 
		'(', '\x3', '\x2', '\x2', '\x2', '\x6', '.', '\x3', '\x2', '\x2', '\x2', 
		'\b', '=', '\x3', '\x2', '\x2', '\x2', '\n', 'N', '\x3', '\x2', '\x2', 
		'\x2', '\f', 'T', '\x3', '\x2', '\x2', '\x2', '\xE', 'Z', '\x3', '\x2', 
		'\x2', '\x2', '\x10', '`', '\x3', '\x2', '\x2', '\x2', '\x12', 'g', '\x3', 
		'\x2', '\x2', '\x2', '\x14', 'y', '\x3', '\x2', '\x2', '\x2', '\x16', 
		'}', '\x3', '\x2', '\x2', '\x2', '\x18', '\x7F', '\x3', '\x2', '\x2', 
		'\x2', '\x1A', '\x8C', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x91', '\x3', 
		'\x2', '\x2', '\x2', '\x1E', '$', '\x5', '\n', '\x6', '\x2', '\x1F', '$', 
		'\x5', '\x6', '\x4', '\x2', ' ', '$', '\x5', '\b', '\x5', '\x2', '!', 
		'$', '\x5', '\x4', '\x3', '\x2', '\"', '$', '\a', '\x1B', '\x2', '\x2', 
		'#', '\x1E', '\x3', '\x2', '\x2', '\x2', '#', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '#', ' ', '\x3', '\x2', '\x2', '\x2', '#', '!', '\x3', '\x2', '\x2', 
		'\x2', '#', '\"', '\x3', '\x2', '\x2', '\x2', '$', '\'', '\x3', '\x2', 
		'\x2', '\x2', '%', '#', '\x3', '\x2', '\x2', '\x2', '%', '&', '\x3', '\x2', 
		'\x2', '\x2', '&', '\x3', '\x3', '\x2', '\x2', '\x2', '\'', '%', '\x3', 
		'\x2', '\x2', '\x2', '(', ')', '\a', '\x3', '\x2', '\x2', ')', '*', '\a', 
		'\x1B', '\x2', '\x2', '*', '+', '\x5', '\x1A', '\xE', '\x2', '+', ',', 
		'\a', '\x4', '\x2', '\x2', ',', '-', '\a', '\x1B', '\x2', '\x2', '-', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '.', '/', '\a', '\x5', '\x2', '\x2', 
		'/', '\x30', '\a', '\x18', '\x2', '\x2', '\x30', '\x34', '\a', '\x6', 
		'\x2', '\x2', '\x31', '\x33', '\x5', '\x12', '\n', '\x2', '\x32', '\x31', 
		'\x3', '\x2', '\x2', '\x2', '\x33', '\x36', '\x3', '\x2', '\x2', '\x2', 
		'\x34', '\x32', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', '\x2', 
		'\x2', '\x2', '\x35', '\x37', '\x3', '\x2', '\x2', '\x2', '\x36', '\x34', 
		'\x3', '\x2', '\x2', '\x2', '\x37', '\x38', '\a', '\a', '\x2', '\x2', 
		'\x38', '\x39', '\a', '\x1B', '\x2', '\x2', '\x39', ':', '\x5', '\x1A', 
		'\xE', '\x2', ':', ';', '\a', '\b', '\x2', '\x2', ';', '<', '\a', '\x1B', 
		'\x2', '\x2', '<', '\a', '\x3', '\x2', '\x2', '\x2', '=', '>', '\a', '\t', 
		'\x2', '\x2', '>', '?', '\a', '\x18', '\x2', '\x2', '?', '\x43', '\a', 
		'\x6', '\x2', '\x2', '@', '\x42', '\x5', '\x12', '\n', '\x2', '\x41', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x42', '\x45', '\x3', '\x2', '\x2', 
		'\x2', '\x43', '\x41', '\x3', '\x2', '\x2', '\x2', '\x43', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\x44', '\x46', '\x3', '\x2', '\x2', '\x2', '\x45', 
		'\x43', '\x3', '\x2', '\x2', '\x2', '\x46', 'G', '\a', '\a', '\x2', '\x2', 
		'G', 'H', '\a', '\n', '\x2', '\x2', 'H', 'I', '\x5', '\x18', '\r', '\x2', 
		'I', 'J', '\a', '\x1B', '\x2', '\x2', 'J', 'K', '\x5', '\x1C', '\xF', 
		'\x2', 'K', 'L', '\a', '\v', '\x2', '\x2', 'L', 'M', '\a', '\x1B', '\x2', 
		'\x2', 'M', '\t', '\x3', '\x2', '\x2', '\x2', 'N', 'O', '\a', '\f', '\x2', 
		'\x2', 'O', 'P', '\a', '\x18', '\x2', '\x2', 'P', 'Q', '\a', '\r', '\x2', 
		'\x2', 'Q', 'R', '\x5', '\x14', '\v', '\x2', 'R', 'S', '\a', '\x1B', '\x2', 
		'\x2', 'S', '\v', '\x3', '\x2', '\x2', '\x2', 'T', 'U', '\a', '\xE', '\x2', 
		'\x2', 'U', 'V', '\a', '\x18', '\x2', '\x2', 'V', 'W', '\a', '\r', '\x2', 
		'\x2', 'W', 'X', '\x5', '\x16', '\f', '\x2', 'X', 'Y', '\a', '\x1B', '\x2', 
		'\x2', 'Y', '\r', '\x3', '\x2', '\x2', '\x2', 'Z', '[', '\a', '\xF', '\x2', 
		'\x2', '[', '\\', '\a', '\x18', '\x2', '\x2', '\\', ']', '\a', '\r', '\x2', 
		'\x2', ']', '^', '\x5', '\x16', '\f', '\x2', '^', '_', '\a', '\x1B', '\x2', 
		'\x2', '_', '\xF', '\x3', '\x2', '\x2', '\x2', '`', '\x61', '\a', '\x10', 
		'\x2', '\x2', '\x61', '\x62', '\x5', '\x16', '\f', '\x2', '\x62', '\x63', 
		'\a', '\x1B', '\x2', '\x2', '\x63', '\x64', '\x5', '\x1A', '\xE', '\x2', 
		'\x64', '\x65', '\a', '\x1B', '\x2', '\x2', '\x65', '\x66', '\a', '\x11', 
		'\x2', '\x2', '\x66', '\x11', '\x3', '\x2', '\x2', '\x2', 'g', 'h', '\a', 
		'\x18', '\x2', '\x2', 'h', 'i', '\a', '\n', '\x2', '\x2', 'i', 'j', '\x5', 
		'\x18', '\r', '\x2', 'j', '\x13', '\x3', '\x2', '\x2', '\x2', 'k', 'z', 
		'\a', '\x19', '\x2', '\x2', 'l', 'z', '\a', '\x1A', '\x2', '\x2', 'm', 
		'o', '\a', '\x12', '\x2', '\x2', 'n', 'p', '\x5', '\x14', '\v', '\x2', 
		'o', 'n', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\x3', '\x2', '\x2', '\x2', 
		'p', 'u', '\x3', '\x2', '\x2', '\x2', 'q', 'r', '\a', '\x13', '\x2', '\x2', 
		'r', 't', '\x5', '\x14', '\v', '\x2', 's', 'q', '\x3', '\x2', '\x2', '\x2', 
		't', 'w', '\x3', '\x2', '\x2', '\x2', 'u', 's', '\x3', '\x2', '\x2', '\x2', 
		'u', 'v', '\x3', '\x2', '\x2', '\x2', 'v', 'x', '\x3', '\x2', '\x2', '\x2', 
		'w', 'u', '\x3', '\x2', '\x2', '\x2', 'x', 'z', '\a', '\x14', '\x2', '\x2', 
		'y', 'k', '\x3', '\x2', '\x2', '\x2', 'y', 'l', '\x3', '\x2', '\x2', '\x2', 
		'y', 'm', '\x3', '\x2', '\x2', '\x2', 'z', '\x15', '\x3', '\x2', '\x2', 
		'\x2', '{', '~', '\x5', '\x14', '\v', '\x2', '|', '~', '\a', '\x18', '\x2', 
		'\x2', '}', '{', '\x3', '\x2', '\x2', '\x2', '}', '|', '\x3', '\x2', '\x2', 
		'\x2', '~', '\x17', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x80', '\t', 
		'\x2', '\x2', '\x2', '\x80', '\x19', '\x3', '\x2', '\x2', '\x2', '\x81', 
		'\x83', '\x5', '\f', '\a', '\x2', '\x82', '\x81', '\x3', '\x2', '\x2', 
		'\x2', '\x83', '\x84', '\x3', '\x2', '\x2', '\x2', '\x84', '\x82', '\x3', 
		'\x2', '\x2', '\x2', '\x84', '\x85', '\x3', '\x2', '\x2', '\x2', '\x85', 
		'\x8D', '\x3', '\x2', '\x2', '\x2', '\x86', '\x88', '\x5', '\x10', '\t', 
		'\x2', '\x87', '\x86', '\x3', '\x2', '\x2', '\x2', '\x88', '\x8B', '\x3', 
		'\x2', '\x2', '\x2', '\x89', '\x87', '\x3', '\x2', '\x2', '\x2', '\x89', 
		'\x8A', '\x3', '\x2', '\x2', '\x2', '\x8A', '\x8D', '\x3', '\x2', '\x2', 
		'\x2', '\x8B', '\x89', '\x3', '\x2', '\x2', '\x2', '\x8C', '\x82', '\x3', 
		'\x2', '\x2', '\x2', '\x8C', '\x89', '\x3', '\x2', '\x2', '\x2', '\x8D', 
		'\x1B', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x90', '\x5', '\xE', '\b', 
		'\x2', '\x8F', '\x8E', '\x3', '\x2', '\x2', '\x2', '\x90', '\x93', '\x3', 
		'\x2', '\x2', '\x2', '\x91', '\x8F', '\x3', '\x2', '\x2', '\x2', '\x91', 
		'\x92', '\x3', '\x2', '\x2', '\x2', '\x92', '\x94', '\x3', '\x2', '\x2', 
		'\x2', '\x93', '\x91', '\x3', '\x2', '\x2', '\x2', '\x94', '\x95', '\a', 
		'\x17', '\x2', '\x2', '\x95', '\x96', '\x5', '\x16', '\f', '\x2', '\x96', 
		'\x97', '\a', '\x1B', '\x2', '\x2', '\x97', '\x1D', '\x3', '\x2', '\x2', 
		'\x2', '\xE', '#', '%', '\x34', '\x43', 'o', 'u', 'y', '}', '\x84', '\x89', 
		'\x8C', '\x91',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
