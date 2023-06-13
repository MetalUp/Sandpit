namespace SandpitCompiler;

public static class Program {
    private static void Main(string[] args) {
        try {
            var fileName = args[0];
            var code = File.ReadAllText(args[0]);

            Pipeline.Handle(code, fileName);
        }
        catch (AggregateException ae) {
            foreach (var ex in ae.InnerExceptions) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}