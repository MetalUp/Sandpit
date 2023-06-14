namespace SandpitCompiler;

public class CompileErrorException : Exception {
    public CompileErrorException(string message) : base(message) { }
}