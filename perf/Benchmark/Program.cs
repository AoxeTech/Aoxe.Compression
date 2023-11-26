var assembly = typeof(Consts).Assembly;
var summaries = BenchmarkRunner.Run(assembly);
foreach (var summary in summaries)
{
    Console.WriteLine(summary.ResultsDirectoryPath);
    Console.WriteLine(string.Join("\r\n", summary.Reports));
}
