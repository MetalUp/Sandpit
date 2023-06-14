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
		ID=10, INT=11, NEWLINE=12, WS=13;
	public const int
		RULE_file = 0, RULE_mainDecl = 1, RULE_procDecl = 2, RULE_constDecl = 3, 
		RULE_varDecl = 4, RULE_expr = 5;
	public static readonly string[] ruleNames = {
		"file", "mainDecl", "procDecl", "constDecl", "varDecl", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, "'main'", "'end main'", "'procedure'", "'('", "')'", "'end procedure'", 
		"'constant'", "'='", "'var'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, "ID", "INT", 
		"NEWLINE", "WS"
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
			State = 18;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__2) | (1L << T__6) | (1L << NEWLINE))) != 0)) {
				{
				State = 16;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case T__6:
					{
					State = 12;
					constDecl();
					}
					break;
				case T__2:
					{
					State = 13;
					procDecl();
					}
					break;
				case T__0:
					{
					State = 14;
					mainDecl();
					}
					break;
				case NEWLINE:
					{
					State = 15;
					Match(NEWLINE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 20;
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
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext[] varDecl() {
			return GetRuleContexts<VarDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext varDecl(int i) {
			return GetRuleContext<VarDeclContext>(i);
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
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 21;
			Match(T__0);
			State = 22;
			Match(NEWLINE);
			State = 24;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 23;
				varDecl();
				}
				}
				State = 26;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==T__8 );
			State = 28;
			Match(T__1);
			State = 29;
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
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext[] varDecl() {
			return GetRuleContexts<VarDeclContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public VarDeclContext varDecl(int i) {
			return GetRuleContext<VarDeclContext>(i);
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
			State = 31;
			Match(T__2);
			State = 32;
			Match(ID);
			State = 33;
			Match(T__3);
			State = 34;
			Match(T__4);
			State = 35;
			Match(NEWLINE);
			State = 37;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 36;
				varDecl();
				}
				}
				State = 39;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==T__8 );
			State = 41;
			Match(T__5);
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

	public partial class ConstDeclContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(SandpitParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(SandpitParser.INT, 0); }
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
		EnterRule(_localctx, 6, RULE_constDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			Match(T__6);
			State = 45;
			Match(ID);
			State = 46;
			Match(T__7);
			State = 47;
			Match(INT);
			State = 48;
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
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NEWLINE() { return GetToken(SandpitParser.NEWLINE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
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
		EnterRule(_localctx, 8, RULE_varDecl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 50;
			Match(T__8);
			State = 51;
			Match(ID);
			State = 54;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__7) {
				{
				State = 52;
				Match(T__7);
				State = 53;
				expr();
				}
			}

			State = 56;
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

	public partial class ExprContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(SandpitParser.INT, 0); }
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
		EnterRule(_localctx, 10, RULE_expr);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 58;
			_la = TokenStream.LA(1);
			if ( !(_la==ID || _la==INT) ) {
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

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\xF', '?', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\a', '\x2', '\x13', '\n', '\x2', '\f', '\x2', 
		'\xE', '\x2', '\x16', '\v', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x6', '\x3', '\x1B', '\n', '\x3', '\r', '\x3', '\xE', '\x3', '\x1C', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x6', '\x4', 
		'(', '\n', '\x4', '\r', '\x4', '\xE', '\x4', ')', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x5', '\x6', '\x39', '\n', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x2', '\x2', '\b', 
		'\x2', '\x4', '\x6', '\b', '\n', '\f', '\x2', '\x3', '\x3', '\x2', '\f', 
		'\r', '\x2', '?', '\x2', '\x14', '\x3', '\x2', '\x2', '\x2', '\x4', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x6', '!', '\x3', '\x2', '\x2', '\x2', '\b', 
		'.', '\x3', '\x2', '\x2', '\x2', '\n', '\x34', '\x3', '\x2', '\x2', '\x2', 
		'\f', '<', '\x3', '\x2', '\x2', '\x2', '\xE', '\x13', '\x5', '\b', '\x5', 
		'\x2', '\xF', '\x13', '\x5', '\x6', '\x4', '\x2', '\x10', '\x13', '\x5', 
		'\x4', '\x3', '\x2', '\x11', '\x13', '\a', '\xE', '\x2', '\x2', '\x12', 
		'\xE', '\x3', '\x2', '\x2', '\x2', '\x12', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x12', '\x10', '\x3', '\x2', '\x2', '\x2', '\x12', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x13', '\x16', '\x3', '\x2', '\x2', '\x2', '\x14', 
		'\x12', '\x3', '\x2', '\x2', '\x2', '\x14', '\x15', '\x3', '\x2', '\x2', 
		'\x2', '\x15', '\x3', '\x3', '\x2', '\x2', '\x2', '\x16', '\x14', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x18', '\a', '\x3', '\x2', '\x2', '\x18', 
		'\x1A', '\a', '\xE', '\x2', '\x2', '\x19', '\x1B', '\x5', '\n', '\x6', 
		'\x2', '\x1A', '\x19', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1C', '\x3', 
		'\x2', '\x2', '\x2', '\x1C', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', 
		'\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', '\x1E', '\x1F', '\a', '\x4', '\x2', '\x2', '\x1F', ' ', '\a', '\xE', 
		'\x2', '\x2', ' ', '\x5', '\x3', '\x2', '\x2', '\x2', '!', '\"', '\a', 
		'\x5', '\x2', '\x2', '\"', '#', '\a', '\f', '\x2', '\x2', '#', '$', '\a', 
		'\x6', '\x2', '\x2', '$', '%', '\a', '\a', '\x2', '\x2', '%', '\'', '\a', 
		'\xE', '\x2', '\x2', '&', '(', '\x5', '\n', '\x6', '\x2', '\'', '&', '\x3', 
		'\x2', '\x2', '\x2', '(', ')', '\x3', '\x2', '\x2', '\x2', ')', '\'', 
		'\x3', '\x2', '\x2', '\x2', ')', '*', '\x3', '\x2', '\x2', '\x2', '*', 
		'+', '\x3', '\x2', '\x2', '\x2', '+', ',', '\a', '\b', '\x2', '\x2', ',', 
		'-', '\a', '\xE', '\x2', '\x2', '-', '\a', '\x3', '\x2', '\x2', '\x2', 
		'.', '/', '\a', '\t', '\x2', '\x2', '/', '\x30', '\a', '\f', '\x2', '\x2', 
		'\x30', '\x31', '\a', '\n', '\x2', '\x2', '\x31', '\x32', '\a', '\r', 
		'\x2', '\x2', '\x32', '\x33', '\a', '\xE', '\x2', '\x2', '\x33', '\t', 
		'\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\a', '\v', '\x2', '\x2', 
		'\x35', '\x38', '\a', '\f', '\x2', '\x2', '\x36', '\x37', '\a', '\n', 
		'\x2', '\x2', '\x37', '\x39', '\x5', '\f', '\a', '\x2', '\x38', '\x36', 
		'\x3', '\x2', '\x2', '\x2', '\x38', '\x39', '\x3', '\x2', '\x2', '\x2', 
		'\x39', ':', '\x3', '\x2', '\x2', '\x2', ':', ';', '\a', '\xE', '\x2', 
		'\x2', ';', '\v', '\x3', '\x2', '\x2', '\x2', '<', '=', '\t', '\x2', '\x2', 
		'\x2', '=', '\r', '\x3', '\x2', '\x2', '\x2', '\a', '\x12', '\x14', '\x1C', 
		')', '\x38',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
