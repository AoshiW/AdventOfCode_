using Kunc.AdventOfCode;
using Kunc.AdventOfCode.Utils;

Console.WriteLine("Hello, Advent of Code");
#if !DEBUG
RunBenchmark<TodayDay, int>();
return;
#endif
var day = new TodayDay();
var input = Client.GetPuzzleInputAsync(day.Year, day.Day).Result;
var span = input.AsSpan().TrimEnd();

Console.WriteLine(day.Part1(span));
Console.WriteLine(day.Part2(span));

public class TodayDay : IDay<int>
{
    public int Year => 2022;
    public string Title => "";
    public int Day => DateTimeOffset.UtcNow.ToOffset(new TimeSpan(-180000000000)).Day; // .FromHours(-5)

    public int Part1(ReadOnlySpan<char> span)
    {
        return default;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        return default;
    }
}
