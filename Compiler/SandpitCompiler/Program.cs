namespace SandpitCompiler;

public static class Program {
    private static Options ParseArgs(string[] args) {
        var flags = args.Where(a => a.StartsWith('-'));
        var fileName = args.Except(flags).SingleOrDefault() ?? "";

        return new Options {
            Version = flags.Any(o => o is "-v" or "--version"),
            CompileCSharp = flags.Any(o => o is "-cc" or "--compileCSharp"),
            FileName = fileName
        };
    }

    private static void HandleOptions(Options opts) {
        if (opts.Version) {
            HandleVersion();
        }
        else {
            HandleCompile(opts);
        }
    }

    private static void HandleVersion() {
        Console.WriteLine("Sandpit compiler version: 0.0.1");
    }

    private static void HandleCompile(Options opts) {
        try {
            Pipeline.Handle(opts);
            Console.WriteLine("Compiled OK");
        }
        catch (AggregateException ae) {
            foreach (var ex in ae.InnerExceptions) {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void Main(string[] args) {
        HandleOptions(ParseArgs(args));
    }
}