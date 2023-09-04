using Antlr4.Runtime;
using CSharpCompiler;
using SandpitCompiler.AST;
using SandpitCompiler.AST.RoleInterface;
using SandpitCompiler.AST.Symbols;
using SandpitCompiler.Model;
using SandpitCompiler.Model.Model;

namespace SandpitCompiler;

public static class Pipeline {
    public static void Handle(Options opts) {
        var fileName = opts.FileName;
        var code = File.ReadAllText(fileName);

        Handle(code, opts);
    }

    public static void Handle(string code, Options? options = null) {
        options ??= new Options();
        var parser = Parse(code);

        var ast = GenerateAst(parser);

        if (parser.NumberOfSyntaxErrors > 0) {
            throw new AggregateException(parser.ErrorListeners.OfType<ErrorListener>().First().SyntaxErrors.Cast<Exception>().ToArray());
        }

        if (ast is null) {
            throw new AggregateException(new CompileErrorException("failed to build AST"));
        }

        var symbolTable = GenerateSymbolTable(ast);

        var secondPassVisitor = SecondPass(ast, symbolTable);

        if (secondPassVisitor.CompileErrors.Count > 0) {
            throw new AggregateException(secondPassVisitor.CompileErrors.Select(e => new CompileErrorException(e)));
        }

        var model = GenerateModel(ast, symbolTable);
        var csCode = GenerateCSharpCode(options.FileName, model);

        if (options.CompileCSharp) {
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
        var baseName = FileNameRoot(fileName);
        Directory.CreateDirectory("obj");
        File.WriteAllText($"obj\\{baseName}.cs", csCode);

        var csproj = @$"
<Project Sdk=""Microsoft.NET.Sdk"">
	<PropertyGroup>
		<OutputType>Exe</OutputType>
		<TargetFramework>net7.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>enable</Nullable>
		<AssemblyName>{baseName}</AssemblyName>
	</PropertyGroup>

    <ItemGroup>
	   <CSFile Include=""{baseName}.cs""/>
    </ItemGroup>

    <ItemGroup>
       <Reference Include=""Sandpit.Compiler.Lib.dll""/>
    </ItemGroup>
</Project>
";

        File.WriteAllText($"obj\\{baseName}.csproj", csproj);

        return csCode;
    }

    private static IDictionary<ModelFlags, bool> SetFlags(SymbolTable symbolTable) {
        IDictionary<ModelFlags, bool> flags = new Dictionary<ModelFlags, bool>();
        // TODO extract rules into factory, rework flags 

        // any use of collections 
        flags[ModelFlags.UsesCollections] = symbolTable.Scopes().SelectMany(s => s.Symbols).Any(s => s.SymbolType is ListType);

        return flags;
    }

    private static SecondPassASTVisitor SecondPass(IASTNode astNode, SymbolTable symbolTable) {
        var astVisitor = new SecondPassASTVisitor(symbolTable);
        astVisitor.Visit(new[] { astNode });
        return astVisitor;
    }

    private static IModel GenerateModel(IASTNode astNode, SymbolTable symbolTable) {
        var astVisitor = new CodeModelASTVisitor(symbolTable, SetFlags(symbolTable));
        return astVisitor.Visit(astNode);
    }

    private static SymbolTable GenerateSymbolTable(IASTNode astNode) {
        var astVisitor = new SymbolTableASTVisitor();
        astVisitor.Visit(astNode);
        return astVisitor.SymbolTable;
    }

    public static IASTNode? GenerateAst(SandpitParser parser) {
        try {
            var fileContext = parser.file();
            var visitor = new ParseTreeVisitor();
            return visitor.Visit(fileContext);
        }
        catch (CompileErrorException e) {
            throw new AggregateException(e);
        }
        catch (Exception e) {
            // AST building failed - fall through for errors 
            Console.WriteLine(e.Message);
        }

        return null;
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