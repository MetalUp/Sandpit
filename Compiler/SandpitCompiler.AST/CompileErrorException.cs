namespace SandpitCompiler.AST;

public class CompileErrorException : Exception {
    public CompileErrorException(string message) : base(message) { }
}