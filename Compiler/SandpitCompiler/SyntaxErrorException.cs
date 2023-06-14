using Antlr4.Runtime;

namespace SandpitCompiler;

internal class SyntaxErrorException : Exception {
    public SyntaxErrorException(IRecognizer recognizer,
                                IToken offendingSymbol,
                                int line,
                                int charPositionInLine,
                                string msg,
                                RecognitionException recognitionException) : base($"line {line}:{charPositionInLine} {msg}") { }
}