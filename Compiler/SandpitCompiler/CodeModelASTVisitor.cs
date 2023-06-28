using System.Collections.Immutable;
using SandpitCompiler.AST.Node;
using SandpitCompiler.Model;
using SandpitCompiler.SymbolTree;

namespace SandpitCompiler;

public class CodeModelASTVisitor {

    private IDictionary<string, bool> Flags { get; set; }

    public CodeModelASTVisitor(IDictionary<string, bool> flags) {
        Flags = flags.ToImmutableDictionary();
    }

    private FileModel BuildFileModel(FileNode fn) {
        var constants = fn.ConstNodes.Select(Visit);
        var procedures = fn.ProcNodes.Select(Visit);
        var functions = fn.FuncNodes.Select(Visit);
        var main = fn.MainNode.Select(Visit).SingleOrDefault();
        return new FileModel(constants, procedures, functions, main);
    }

    private MainModel BuildMainModel(MainNode mn) => new(Visit(mn.Body));

    private VarDeclModel BuildVarDeclModel(VarDeclNode vdn) => new(vdn.ID.Text, vdn.Expr.Text);

    private ConstDeclModel BuildConstDeclModel(ConstDeclNode vdn) => new(vdn.ID.Text, (ValueModel)Visit(vdn.Val));

    private FuncModel BuildFuncModel(FuncNode fn) => new(fn.ID.Text, fn.Type.Text, fn.ParamNodes.Select(Visit), Visit(fn.Body));

    private VarDeclModel BuildLetDeclModel(LetDeclNode ldn) => new(ldn.ID.Text, ldn.Expr.Text);

    private ProcModel BuildProcModel(ProcNode pn) => new(pn.ID.Text, pn.Parameters.Select(Visit), Visit(pn.Body));

    private ParamModel BuildParamModel(ParamNode pn) => new(pn.ID.Text, pn.Type.Text);

    private FuncBodyModel BuildFuncBodyModel(FuncBodyNode bn) => new(bn.Return.Text, bn.LetNodes.Select(Visit));

    private BodyModel BuildBodyModel(BodyNode bn) => new(bn.StatNodes.Select(Visit));

    public IModel Visit(ASTNode astNode) {
        return astNode switch {
            ConstDeclNode cdn => BuildConstDeclModel(cdn),
            FileNode fn => BuildFileModel(fn),
            MainNode mn => BuildMainModel(mn),
            VarDeclNode vdn => BuildVarDeclModel(vdn),
            LetDeclNode ldn => BuildLetDeclModel(ldn),
            ProcNode pn => BuildProcModel(pn),
            FuncNode fn => BuildFuncModel(fn),
            ParamNode pn => BuildParamModel(pn),
            FuncBodyNode bn => BuildFuncBodyModel(bn),
            ValueNode vn => BuildValueModel(vn),
            BodyNode bn => BuildBodyModel(bn),
            WhileNode sn => BuildWhileModel(sn),
            ProcStatNode sn => BuildProcStatModel(sn),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

    private IModel BuildProcStatModel(ProcStatNode psn) => new ProcStatModel(psn.ID.Text, psn.Parameters.Select(Visit).ToArray());

    private IModel BuildWhileModel(WhileNode sn) => new WhileModel(Visit(sn.Expr), Visit(sn.Body));

    private IModel BuildValueModel(ValueNode vn) {
        return vn switch {
            ScalarValueNode svn => new ValueModel(svn.Text, svn.InferredType),
            ListNode ln => new ValueModel(ln.Texts, ln.InferredType),
            BinaryOperatorNode bon => new BinaryOperatorModel(Visit(bon.Op), Visit(bon.Lhs), Visit(bon.Rhs)),
            _ => throw new NotImplementedException()
        };
    }
}