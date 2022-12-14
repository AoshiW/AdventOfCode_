using Kunc.AdventOfCode;

Console.WriteLine("Hello, Advent of Code");
RunPuzzle();
RunBenchmark<TodayDay, int>();

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
