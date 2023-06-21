using SandpitCompiler.AST;
using SandpitCompiler.Model;

namespace SandpitCompiler;

public class ASTVisitor {
    private FileModel BuildFileModel(FileNode fn) {
        var constants = fn.ConstNodes.Select(Visit);
        var procedures = fn.ProcNodes.Select(Visit);
        var functions = fn.FuncNodes.Select(Visit);
        var main = fn.MainNode is { } mn ? Visit(mn) : null;
        return new FileModel(constants, procedures, functions, main);
    }

    private MainModel BuildMainModel(MainNode mn) {
        var vars = mn.VarNodes.Select(Visit);
        return new MainModel(vars);
    }

    private VarDeclModel BuildVarDeclModel(VarDeclNode vdn) => new(vdn.ID.Text, vdn.Expr.Text);

    private ConstDeclModel BuildConstDeclModel(ConstDeclNode vdn) => new(vdn.ID.Text, (ValueModel)Visit(vdn.Val));

    private FuncModel BuildFuncModel(FuncNode fn) => new(fn.ID.Text, fn.Type.Text, fn.ParamNodes.Select(Visit), Visit(fn.Body));

    private VarDeclModel BuildLetDeclModel(LetDeclNode ldn) => new(ldn.ID.Text, ldn.Expr.Text);

    private ProcModel BuildProcModel(ProcNode pn) => new(pn.ID.Text, pn.ParamNodes.Select(Visit), pn.VarNodes.Select(Visit));

    private ParamModel BuildParamModel(ParamNode pn) => new(pn.ID.Text, pn.Type.Text);

    private FuncBodyModel BuildFuncBodyModel(FuncBodyNode bn) => new(bn.Return.Text, bn.LetNodes.Select(Visit));

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
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

    private IModel BuildValueModel(ValueNode vn) {
        return vn switch {
            ScalarValueNode svn => new ValueModel(svn.Text, svn.InferredType),
            ListNode ln => new ValueModel(ln.Texts, ln.InferredType),
            _ => throw new NotImplementedException()
        };

    }
}