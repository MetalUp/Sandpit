using System.Collections.Immutable;
using SandpitCompiler.AST.Node;
using SandpitCompiler.Model;
using SandpitCompiler.Model.Model;
using SandpitCompiler.SymbolTree;

namespace SandpitCompiler;

public class CodeModelASTVisitor {
    public SymbolTable SymbolTable { get; }

    public CodeModelASTVisitor(SymbolTable symbolTable,   IDictionary<ModelFlags, bool> flags) {
        SymbolTable = symbolTable;
        Flags = flags.ToImmutableDictionary();
    }

    private IDictionary<ModelFlags, bool> Flags { get; }

    private FileModel BuildFileModel(FileNode fn) {
        var constants = fn.ConstNodes.Select(Visit);
        var procedures = fn.ProcNodes.Select(Visit);
        var functions = fn.FuncNodes.Select(Visit);
        var main = fn.MainNode.Select(Visit).SingleOrDefault();
        return new FileModel(Flags, constants, procedures, functions, main);
    }

    private MainModel BuildMainModel(MainNode mn) => new(mn.ProcedureBlock.Select(Visit));

    private VarDeclModel BuildVarDeclModel(VarDefnNode vdn) => new(vdn.ID.Text, Visit(vdn.Expr));

    private ConstDeclModel BuildConstDeclModel(ConstDefnNode vdn) {
        var id = vdn.ID.Text;
        var type = SymbolTable.GlobalScope.Resolve(id)?.SymbolType;

        return new ConstDeclModel(id, Visit(vdn.Val), new TypeModel(type));
    }

    private FuncModel BuildFuncModel(FuncDefnNode fn) {
        var id = fn.ID.Text;
        var type = SymbolTable.GlobalScope.Resolve(id)?.SymbolType ?? throw new ArgumentNullException();

        return new(id, new TypeModel(type), fn.Parameters.Select(Visit), fn.FunctionBlock.Select(Visit), Visit(fn.ReturnExpression));
    }

    private VarDeclModel BuildLetDeclModel(LetDefnNode ldn) => new(ldn.ID.Text, Visit(ldn.Expr));

    private ProcModel BuildProcModel(ProcDefnNode pn) => new(pn.ID.Text, pn.Parameters.Select(Visit), pn.ProcedureBlock.Select(Visit));

    private ParamModel BuildParamModel(ParamDefnNode pn) => new(pn.ID.Text, ModelHelpers.TypeLookup(pn.Type));

    public IModel Visit(ASTNode astNode) {
        return astNode switch {
            ConstDefnNode cdn => BuildConstDeclModel(cdn),
            FileNode fn => BuildFileModel(fn),
            MainNode mn => BuildMainModel(mn),
            VarDefnNode vdn => BuildVarDeclModel(vdn),
            LetDefnNode ldn => BuildLetDeclModel(ldn),
            ProcDefnNode pn => BuildProcModel(pn),
            FuncDefnNode fn => BuildFuncModel(fn),
            ParamDefnNode pn => BuildParamModel(pn),

            ValueNode vn => BuildValueModel(vn),
            WhileStatNode sn => BuildWhileModel(sn),
            ProcStatNode sn => BuildProcStatModel(sn),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

    private IModel BuildProcStatModel(ProcStatNode psn) => new ProcStatModel(psn.ID.Text, psn.Parameters.Select(Visit).ToArray());

    private IModel BuildWhileModel(WhileStatNode sn) => new WhileModel(Visit(sn.Condition), sn.ProcedureBlock.Select(Visit));

    private IModel BuildValueModel(ValueNode vn) {
        return vn switch {
            ScalarValueNode svn => new ValueModel(svn.Text, ModelHelpers.TypeLookup(svn.InferredType)),
            ListValueNode ln => new ValueModel(ln.Texts, $"IList<{ModelHelpers.TypeLookup(ln.InferredType)}>", $"List<{ModelHelpers.TypeLookup(ln.InferredType)}>"),
            BinaryValueNode bon => new BinaryOperatorModel(Visit(bon.Op), Visit(bon.Lhs), Visit(bon.Rhs)),
            OperatorValueNode on => new ValueModel(ModelHelpers.OperatorLookup(on.Operator), ModelHelpers.TypeLookup(on.InferredType)),
            IndexValueNode ivn => new IndexedValueModel(Visit(ivn.Expr), Visit(ivn.Index)),
            RangeValueNode rvn => new RangeValueModel(rvn.Prefix, Visit(rvn.From), rvn.To is { } to ? Visit(to) : null),
            TernaryValueNode tvn => new TernaryValueModel(Visit(tvn.Control), Visit(tvn.Lhs), Visit(tvn.Rhs)),
            FunctionCallValueNode fn => new FuncCallModel(fn.ID.Text, fn.Parameters.Select(Visit).ToArray()),
            TupleValueNode tvn => new TupleValueModel(tvn.ValueNodes.Select(Visit).ToArray()),
            LambdaValueNode lvn => new LambdaValueModel(lvn.Args.Select(Visit).ToArray(), Visit(lvn.Expr)),
            DereferenceNode dn => new DereferenceModel(Visit(dn.Expr), Visit(dn.ID)),
            _ => throw new NotImplementedException()
        };
    }
}