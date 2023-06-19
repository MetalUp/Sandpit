﻿using SandpitCompiler.AST;
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

    private VarDeclModel BuildVarDeclModel(VarDeclNode vdn) => new(vdn.ID.Text ?? "", vdn.Expr.Text ?? "");

    private ConstDeclModel BuildConstDeclModel(ConstDeclNode vdn) => new(vdn.ID.Text ?? "", vdn.Int.Text ?? "");

    private ProcModel BuildFuncNode(FuncNode fn) => new(fn.ID.Text ?? "", fn.LetNodes.Select(Visit));

    private VarDeclModel BuildLetDeclModel(LetDeclNode ldn) => new(ldn.ID.Text ?? "", ldn.Expr.Text ?? "");

    private ProcModel BuildProcNode(ProcNode pn) => new(pn.ID.Text ?? "", pn.VarNodes.Select(Visit));

    public IModel Visit(ASTNode astNode) {
        return astNode switch {
            ConstDeclNode cdn => BuildConstDeclModel(cdn),
            FileNode fn => BuildFileModel(fn),
            MainNode mn => BuildMainModel(mn),
            VarDeclNode vdn => BuildVarDeclModel(vdn),
            LetDeclNode ldn => BuildLetDeclModel(ldn),
            ProcNode pn => BuildProcNode(pn),
            FuncNode fn => BuildFuncNode(fn),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }

   
}