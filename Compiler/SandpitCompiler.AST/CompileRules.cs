namespace SandpitCompiler.AST;

public static class CompileRules {
    public static ASTNode OnlyOneMainRule(ASTNode node) {
        if (node is FileNode { MainNode.Length: > 1 }) {
            throw new CompileErrorException("more than one main");
        }

        return node;
    }
}