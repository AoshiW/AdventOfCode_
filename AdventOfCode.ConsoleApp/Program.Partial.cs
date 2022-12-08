using AdventOfCode.ConsoleApp;
using BenchmarkDotNet.Running;
using Kunc.AdventOfCode;

partial class Program
{
    public static readonly IAdventOfCodeClient Client;

    static Program()
    {
        var aocSession = Environment.GetEnvironmentVariable("aoc_session") ?? throw new ArgumentNullException("aocSession");
        Client = AdventOfCodeClient.CreateWithFileCache(
            new() { Session = aocSession },
            new() { PuzzleDirectory = Path.Combine("..", "..", "..", "..", "aoc_cache", "inputs") }
            );
    }

    public static void RunBenchmark<TDay, TResult>() where TDay : IDay<TResult>, new()
    {
        BenchmarkRunner.Run<DayBenchmark<TDay, TResult>>();
    }
}
