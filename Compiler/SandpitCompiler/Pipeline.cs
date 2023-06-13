using Antlr4.Runtime;
using CSharpCompiler;
using SandpitCompiler.AST;
using SandpitCompiler.Model;

namespace SandpitCompiler;

public static class Pipeline {
    public static void Handle(Options opts) {
        var fileName = opts.FileName;
        var code = File.ReadAllText(fileName);

        Handle(code, opts);
    }

    public static void Handle(string code,  Options? options = null) {
        options ??= new Options();
        var parser = Parse(code);
        var ast = GenerateAst(parser);
        if (parser.NumberOfSyntaxErrors > 0) {
            throw new AggregateException(parser.ErrorListeners.OfType<ErrorListener>().First().SyntaxErrors.Cast<Exception>().ToArray());
        }

        var model = GenerateModel(ast);
        var csCode = GenerateCSharpCode(options.FileName, model);

        if (options.CompileCSharp == true) {
            CompileCsharpCode(options.FileName, csCode, model.HasMain);
        }
    }

    private static string FileNameRoot(string fileName) => fileName.Split('.').First();

    private static void CompileCsharpCode(string fn, string csCode, bool console) {
        var asm = Compiler.Compile(csCode, console);

        File.WriteAllBytes($"{FileNameRoot(fn)}.dll", asm);
    }

    private static string GenerateCSharpCode(string fileName, IModel model) {
        var csCode = model.ToString();
        File.WriteAllText($"{FileNameRoot(fileName)}.cs", csCode);
        return csCode;
    }

    private static IModel GenerateModel(ASTNode astNode) {
        var astVisitor = new SandpitASTVisitor();
        return astVisitor.Visit(astNode);
    }

    public static ASTNode GenerateAst(SandpitParser parser) {
        var fileContext = parser.file();
        var visitor = new BasicSandpitVisitor();
        return visitor.Visit(fileContext);
    }

    public static SandpitParser Parse(string code) {
        var inputStream = new AntlrInputStream(code);
        var lexer = new SandpitLexer(inputStream);
        // todo lexer error handling ?

        var tokenStream = new CommonTokenStream(lexer);
        var parser = new SandpitParser(tokenStream);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        return parser;
    }

    private class ErrorListener : BaseErrorListener {
        public IList<SyntaxErrorException> SyntaxErrors { get; } = new List<SyntaxErrorException>();

        public override void SyntaxError(TextWriter output,
                                         IRecognizer recognizer,
                                         IToken offendingSymbol,
                                         int line,
                                         int charPositionInLine,
                                         string msg,
                                         RecognitionException e) {
            SyntaxErrors.Add(new SyntaxErrorException(recognizer, offendingSymbol, line, charPositionInLine, msg, e));
        }
    }
}