using System;
using System.Collections.Immutable;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Model;
using SandpitCompiler.Model.Model;

namespace SandpitCompiler;

public class CodeModelASTVisitor {
    private IScope currentScope;

    public CodeModelASTVisitor(SymbolTable symbolTable, IDictionary<ModelFlags, bool> flags) {
        SymbolTable = symbolTable;
        currentScope = symbolTable.GlobalScope;
        Flags = flags.ToImmutableDictionary();
    }

    private SymbolTable SymbolTable { get; }

    private IDictionary<ModelFlags, bool> Flags { get; }

    private void Enter(IASTNode node) {
        switch (node) {
            case IBlock:
                currentScope = currentScope.Resolve("main") as IScope ?? throw new ArgumentNullException();
                break;
            case IProcedure p:
                currentScope = currentScope.Resolve(p.ID.Text) as IScope ?? throw new ArgumentNullException();
                break;
            case IFunction f:
                currentScope = currentScope.Resolve(f.ID.Text) as IScope ?? throw new ArgumentNullException();
                break;
            case LetDefnNode l:
                currentScope = currentScope.ChildScopes.FirstOrDefault() ?? throw new ArgumentNullException();
                break;
        }
    }

    private void Exit(IASTNode node) {
        if (node is IBlock or IProcedure or IFunction or LetDefnNode) {
            currentScope = currentScope.EnclosingScope ?? throw new ArgumentNullException();
        }
    }

    private IModel HandleScope<T>(Func<T, IModel> func, T node) where T : IASTNode {
        Enter(node);
        try {
            return func(node);
        }
        finally {
            Exit(node);
        }
    }

    private FileModel BuildFileModel(FileNode fn) {
        var constants = fn.ConstNodes.Select(Visit);
        var procedures = fn.ProcNodes.Select(Visit);
        var functions = fn.FuncNodes.Select(Visit);
        var main = fn.MainNode.Select(Visit).SingleOrDefault();
        return new FileModel(Flags, constants, procedures, functions, main);
    }

    private MainModel BuildMainModel(MainNode mn) => new(mn.ProcedureBlock.Select(Visit));

    private VarDeclModel BuildVarDeclModel(VarDefinitionNode vdn) => new(vdn.ID.Text, Visit(vdn.Expr));

    private ConstDeclModel BuildConstDeclModel(ConstDefinitionNode vdn) {
        var id = vdn.ID.Text;
        var type = currentScope.Resolve(id)?.SymbolType;

        return new ConstDeclModel(id, Visit(vdn.Expression), new TypeModel(type, currentScope));
    }

    private FuncModel BuildFuncModel(FunctionDefinitionNode fn) {
        var id = fn.ID.Text;
        var type = currentScope.Resolve(id)?.SymbolType ?? throw new ArgumentNullException();

        return new FuncModel(id, new TypeModel(type, currentScope), fn.Parameters.Select(Visit), fn.FunctionBlock.Select(Visit), Visit(fn.ReturnExpression));
    }

    private LetDeclModel BuildLetDeclModel(LetDefnNode ldn) => new( ldn.Values.Select(t => (Visit(t.id), Visit(t.expr))).ToArray(), Visit(ldn.ReturnExpression), new TypeModel(ldn.ReturnExpression.SymbolType, currentScope));

    private ProcModel BuildProcModel(ProcedureDefinitionNode pn) => new(pn.ID.Text, pn.Parameters.Select(Visit), pn.ProcedureBlock.Select(Visit));

    private ParamModel BuildParamModel(ParameterDefinitionNode pn) => new(pn.ID.Text, ModelHelpers.TypeLookup(pn.Type));

    public IModel Visit(IASTNode astNode) {
        return astNode switch {
            ConstDefinitionNode cdn => HandleScope(BuildConstDeclModel, cdn),
            FileNode fn => HandleScope(BuildFileModel, fn),
            MainNode mn => HandleScope(BuildMainModel, mn),
            VarDefinitionNode vdn => HandleScope(BuildVarDeclModel, vdn),
            LetDefnNode ldn => HandleScope(BuildLetDeclModel, ldn),
            ProcedureDefinitionNode pn => HandleScope(BuildProcModel, pn),
            FunctionDefinitionNode fn => HandleScope(BuildFuncModel, fn),
            ParameterDefinitionNode pn => HandleScope(BuildParamModel, pn),
            ScalarValueNode svn => new ValueModel(svn.Text),
            ListExpressionNode ln => HandleScope(BuildListValueModel, ln),
            BinaryExpressionNode bon => new BinaryOperatorModel(Visit(bon.Op), Visit(bon.Lhs), Visit(bon.Rhs)),
            OperatorValueNode on => new ValueModel(ModelHelpers.OperatorLookup(on.Operator)),
            IndexedExpressionNode ivn => new IndexedValueModel(Visit(ivn.Expr), Visit(ivn.Index), new TypeModel(ivn.Expr.SymbolType, currentScope)),
            RangeExpressionNode rvn => new RangeValueModel(rvn.Prefix, Visit(rvn.From), rvn.To is { } to ? Visit(to) : null),
            TernaryExpressionNode tvn => new TernaryValueModel(Visit(tvn.Control), Visit(tvn.Lhs), Visit(tvn.Rhs)),
            FunctionExpressionNode fn => new FuncCallModel(fn.ID.Text, fn.Parameters.Select(Visit).ToArray()),
            TupleExpressionNode tvn => new TupleValueModel(tvn.ValueNodes.Select(Visit).ToArray()),
            LambdaExpressionNode lvn => new LambdaValueModel(lvn.Args.Select(Visit).ToArray(), Visit(lvn.Expr)),
            DereferenceExpressionNode dn => new DereferenceModel(Visit(dn.Expression), Visit(dn.ID)),
            WhileStatementNode sn => HandleScope(BuildWhileModel, sn),
            ProcedureStatementNode sn => HandleScope(BuildProcStatModel, sn),
            ValuesNode vn => new ValueModel(vn.Values.Select(Visit).ToArray()),
            AssignmentNode an => new AssignmentModel(an.ID.Text, Visit(an.Expr)),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

    private IModel BuildListValueModel(ListExpressionNode ln) {
        var type = ln.SymbolType;

        return new ValueModel(ln.Texts, new TypeModel(type, currentScope));
    }

    private IModel BuildProcStatModel(ProcedureStatementNode psn) => new ProcStatModel(psn.ID.Text, psn.Parameters.Select(Visit).ToArray());

    private IModel BuildWhileModel(WhileStatementNode sn) => new WhileModel(Visit(sn.Condition), sn.ProcedureBlock.Select(Visit));
}