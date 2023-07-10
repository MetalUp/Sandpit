using System.Collections.Immutable;
using SandpitCompiler.AST.Node;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.Model;
using SandpitCompiler.Model.Model;
using SandpitCompiler.SymbolTree;

namespace SandpitCompiler;

public class CodeModelASTVisitor {
    public CodeModelASTVisitor(SymbolTable symbolTable, IDictionary<ModelFlags, bool> flags) {
        SymbolTable = symbolTable;
        Flags = flags.ToImmutableDictionary();
    }

    public SymbolTable SymbolTable { get; }

    private IDictionary<ModelFlags, bool> Flags { get; }

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
        var type = SymbolTable.GlobalScope.Resolve(id)?.SymbolType;

        return new ConstDeclModel(id, Visit(vdn.Expression), new TypeModel(type));
    }

    private FuncModel BuildFuncModel(FunctionDefinitionNode fn) {
        var id = fn.ID.Text;
        var type = SymbolTable.GlobalScope.Resolve(id)?.SymbolType ?? throw new ArgumentNullException();

        return new FuncModel(id, new TypeModel(type), fn.Parameters.Select(Visit), fn.FunctionBlock.Select(Visit), Visit(fn.ReturnExpression));
    }

    private VarDeclModel BuildLetDeclModel(LetDefnNode ldn) => new(ldn.ID.Text, Visit(ldn.Expr));

    private ProcModel BuildProcModel(ProcedureDefinitionNode pn) => new(pn.ID.Text, pn.Parameters.Select(Visit), pn.ProcedureBlock.Select(Visit));

    private ParamModel BuildParamModel(ParameterDefinitionNode pn) => new(pn.ID.Text, ModelHelpers.TypeLookup(pn.Type));

    public IModel Visit(IASTNode astNode) {
        return astNode switch {
            ConstDefinitionNode cdn => BuildConstDeclModel(cdn),
            FileNode fn => BuildFileModel(fn),
            MainNode mn => BuildMainModel(mn),
            VarDefinitionNode vdn => BuildVarDeclModel(vdn),
            LetDefnNode ldn => BuildLetDeclModel(ldn),
            ProcedureDefinitionNode pn => BuildProcModel(pn),
            FunctionDefinitionNode fn => BuildFuncModel(fn),
            ParameterDefinitionNode pn => BuildParamModel(pn),
            ScalarValueNode svn => new ValueModel(svn.Text),
            ListExpressionNode ln => BuildListValueModel(ln),
            BinaryExpressionNode bon => new BinaryOperatorModel(Visit(bon.Op), Visit(bon.Lhs), Visit(bon.Rhs)),
            OperatorValueNode on => new ValueModel(ModelHelpers.OperatorLookup(on.Operator)),
            IndexedExpressionNode ivn => new IndexedValueModel(Visit(ivn.Expr), Visit(ivn.Index)),
            RangeExpressionNode rvn => new RangeValueModel(rvn.Prefix, Visit(rvn.From), rvn.To is { } to ? Visit(to) : null),
            TernaryExpressionNode tvn => new TernaryValueModel(Visit(tvn.Control), Visit(tvn.Lhs), Visit(tvn.Rhs)),
            FunctionExpressionNode fn => new FuncCallModel(fn.ID.Text, fn.Parameters.Select(Visit).ToArray()),
            TupleExpressionNode tvn => new TupleValueModel(tvn.ValueNodes.Select(Visit).ToArray()),
            LambdaExpressionNode lvn => new LambdaValueModel(lvn.Args.Select(Visit).ToArray(), Visit(lvn.Expr)),
            DereferenceExpressionNode dn => new DereferenceModel(Visit(dn.Expression), Visit(dn.ID)),
            WhileStatementNode sn => BuildWhileModel(sn),
            ProcedureStatementNode sn => BuildProcStatModel(sn),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

    private IModel BuildListValueModel(ListExpressionNode ln) {
        var type = ln.SymbolType;

        return new ValueModel(ln.Texts, new TypeModel(type));
    }

    private IModel BuildProcStatModel(ProcedureStatementNode psn) => new ProcStatModel(psn.ID.Text, psn.Parameters.Select(Visit).ToArray());

    private IModel BuildWhileModel(WhileStatementNode sn) => new WhileModel(Visit(sn.Condition), sn.ProcedureBlock.Select(Visit));
}