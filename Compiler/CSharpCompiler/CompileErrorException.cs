using Microsoft.CodeAnalysis;

namespace CSharpCompiler;

internal class CompileErrorException : Exception {
    public CompileErrorException(Diagnostic diagnostic) => Diagnostic = diagnostic;

    public Diagnostic Diagnostic { get; }

    public override string Message => Diagnostic.ToString();
}