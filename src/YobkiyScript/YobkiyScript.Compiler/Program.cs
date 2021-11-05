using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]) || !File.Exists(args[0]))
{
    Console.Error.WriteLine("Ne yobkiy!");
    Environment.Exit(1);
}

var src = await File.ReadAllTextAsync(args[0]);

if (src.Contains("//") || src.Contains("/*"))
{
    Console.Error.WriteLine("Документация нам не нужна!");
    Environment.Exit(2);
}

var processed = src
    .Replace("юзаем", "using")
    .Replace("славянский", "public")
    .Replace("сикрет", "private")
    .Replace("ёбкий", "class")
    .Replace("аниме", "readonly")
    .Replace("хзхто", "var")
    .Replace("уф", "if")
    .Replace("или", "else")
    .Replace("да", "true")
    .Replace("нет", "false")
    .Replace("уйди", "return")
    .Replace("Ёбкий", "System")
    .Replace("ExtremeCode", "Microsoft");

var asmr = Compile(processed);

if (asmr == null)
{
    Console.Error.WriteLine("Ne yobkiy!");
    Environment.Exit(3);
}

if (Path.GetExtension(args[0]) != "yobkiy")
{
    Console.Error.WriteLine("Yobkiy ne yobkiy!");
    Environment.Exit(3);
}

await File.WriteAllBytesAsync("Yobkiy.exe", asmr);

Console.WriteLine("Yobkiy!");

static byte[]? Compile(string sourceCode)
{
    using var peStream = new MemoryStream();
    var result = GenerateCode(sourceCode).Emit(peStream);

    if (!result.Success)
    {
        var failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

        foreach (var diagnostic in failures)
        {
            Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
        }

        return null;
    }

    peStream.Seek(0, SeekOrigin.Begin);

    return peStream.ToArray();
}

static CSharpCompilation GenerateCode(string src)
{
    var codeString = SourceText.From(src);
    var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp10);

    var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);
    var references = new List<MetadataReference>();

    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
    {
        try
        {
            references.Add(MetadataReference.CreateFromFile(asm.Location));
        }
        catch (NotSupportedException)
        {
            // dynamic assembly
        }
    }

    return CSharpCompilation.Create("Yobkiy.exe",
        new[] { parsedSyntaxTree },
        references: references,
        options: new CSharpCompilationOptions(OutputKind.ConsoleApplication,
            optimizationLevel: OptimizationLevel.Release,
            assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
}
