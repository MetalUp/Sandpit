using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace CSharpCompiler;

public static class Compiler {

    private static readonly MetadataReference[] DotNetReferences = {
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Runtime").Location), // System.Runtime
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Collections").Location), // System.Collections
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Private.CoreLib").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Runtime").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Console").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("netstandard").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Text.RegularExpressions").Location), // IMPORTANT!
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Linq").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Linq.Expressions").Location), // IMPORTANT!
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.IO").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Net.Primitives").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Net.Http").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Private.Uri").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Reflection").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.ComponentModel.Primitives").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Globalization").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Collections.Concurrent").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Collections.NonGeneric").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("System.Collections.Immutable").Location),
        MetadataReference.CreateFromFile(AppDomain.CurrentDomain.Load("Microsoft.CSharp").Location)
    };

    private static readonly MetadataReference[] CSharpReferences = {
        MetadataReference.CreateFromFile(typeof(CSharpArgumentInfo).Assembly.Location)
    };

    private static readonly MetadataReference[] References = DotNetReferences.Union(CSharpReferences).ToArray();

    private static byte[] Compile(string code, Func<string, Compilation> generateCode) {
        using var peStream = new MemoryStream();

        var result = generateCode(code).Emit(peStream);

        if (!result.Success) {
            var failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error).ToArray();
            throw new AggregateException(failures.Select(d => new CompileErrorException(d)).Cast<Exception>().ToArray());
        }

        peStream.Seek(0, SeekOrigin.Begin);

        return peStream.ToArray();
    }

    private static CSharpParseOptions GetOptions() => CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp11);

    public static byte[] Compile(string code, bool console) => Compile(code, GenerateGenerateCode(References, console));

    private static Func<string, CSharpCompilation> GenerateGenerateCode(MetadataReference[] references, bool console) =>
        sourceCode => GenerateCode(sourceCode, references, console);

    private static CSharpCompilation GenerateCode(string sourceCode, MetadataReference[] references, bool console) {
        var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(sourceCode), GetOptions());

        return CSharpCompilation.Create("compiled",
                                        new[] { parsedSyntaxTree },
                                        references,
                                        new CSharpCompilationOptions(console ? OutputKind.ConsoleApplication : OutputKind.DynamicallyLinkedLibrary,
                                                                     optimizationLevel: OptimizationLevel.Release,
                                                                     assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
    }
}