﻿using SandpitCompiler.AST;
using SandpitCompiler.Model;

namespace SandpitCompiler;

public class SandpitASTVisitor {
    private IModel BuildFileModel(FileNode fn) {
        var constants = fn.ConstNodes.Select(Visit);
        var main = fn.MainNode is { } mn ? Visit(mn) : null;
        return new FileModel(constants, main);
    }

    private IModel BuildMainModel(MainNode mn) {
        var vars = mn.VarNodes.Select(Visit);
        return new MainModel(vars);
    }

    private IModel BuildVarDeclModel(VarDeclNode vdn) => new VarDeclModel(vdn.ID.Text ?? "", vdn.Expr.Text ?? "");

    private IModel BuildConstDeclModel(ConstDeclNode vdn) => new ConstDeclModel(vdn.ID.Text ?? "", vdn.Int.Text ?? "");

    public IModel Visit(ASTNode astNode) {
        return astNode switch {
            ConstDeclNode cdn => BuildConstDeclModel(cdn),
            FileNode fn => BuildFileModel(fn),
            MainNode mn => BuildMainModel(mn),
            VarDeclNode vdn => BuildVarDeclModel(vdn),
            null => throw new NotImplementedException("null"),
            _ => throw new NotImplementedException(astNode.GetType().ToString() ?? "null")
        };
    }
}