using AdventOfCode.ConsoleApp;
using BenchmarkDotNet.Running;
using Kunc.AdventOfCode;
using System.Diagnostics;

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

    [Conditional("RELEASE")]
    public static void RunBenchmark<TDay, TResult>() where TDay : IDay<TResult>, new()
    {
        BenchmarkRunner.Run<DayBenchmark<TDay, TResult>>();
    }

    public static void RunPuzzle()
    {
        var day = new TodayDay();
        var input = Client.GetPuzzleInputAsync(day.Year, day.Day).Result;
        var span = input.AsSpan().TrimEnd();
        var stopWatch = Stopwatch.StartNew();
        Console.WriteLine(day.Part1(span));
        Console.WriteLine(stopWatch.Elapsed);
        stopWatch.Restart();
        Console.WriteLine(day.Part2(span));
        Console.WriteLine(stopWatch.Elapsed);
    }
}
