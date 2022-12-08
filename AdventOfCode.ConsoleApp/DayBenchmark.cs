using BenchmarkDotNet.Attributes;
using Kunc.AdventOfCode;

namespace AdventOfCode.ConsoleApp;

[MemoryDiagnoser]
public class DayBenchmark<TDay, TResult> where TDay : IDay<TResult>, new()
{
    readonly TDay _day = new();

    string Input => _input ??= Program.Client.GetPuzzleInputAsync(_day.Year, _day.Day).Result.TrimEnd();
    string? _input;

    [Benchmark]
    public TResult Part1() => _day.Part1(Input);

    [Benchmark]
    public TResult Part2() => _day.Part2(Input);
}
