namespace AdventOfCode.Y2021;

public class D02 : IDay<int>
{
    public int Year => 2021;

    public int Day => 2;

    public string Title => "Dive!";

    public int Part1(ReadOnlySpan<char> span)
    {
        int horizontal = 0, depth = 0;
        foreach (var item in span.EnumerateLines())
        {
            int num = int.Parse(item.Slice(item.IndexOf(' ') + 1));
            if (item.StartsWith("down", StringComparison.OrdinalIgnoreCase))
            {
                depth += num;
            }
            else if (item.StartsWith("up", StringComparison.OrdinalIgnoreCase))
            {
                depth -= num;
            }
            else
            {
                horizontal += num;
            }
        }
        return horizontal * depth;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int horizontal = 0, depth = 0, aim = 0;
        foreach (var item in span.EnumerateLines())
        {
            int num = int.Parse(item.Slice(item.IndexOf(' ') + 1));
            if (item.StartsWith("down", StringComparison.OrdinalIgnoreCase))
            {
                aim += num;
            }
            else if (item.StartsWith("up", StringComparison.OrdinalIgnoreCase))
            {
                aim -= num;
            }
            else
            {
                horizontal += num;
                depth += aim * num;
            }
        }
        return horizontal * depth;
    }
}
