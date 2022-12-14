namespace AdventOfCode.Y2017;

public class D24 : IDay<int>
{
    public int Year => 2017;

    public int Day => 24;

    public string Title => "Electromagnetic Moat";

    public int Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        return 0;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        return default;
    }

    static List<(int, int)> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<(int, int)>();
        foreach (var item in span.EnumerateLines())
        {
            var index = item.IndexOf('/');
            var n1 = int.Parse(item.Slice(0, index));
            var n2 = int.Parse(item.Slice(index + 1));
            list.Add((n1, n2));
        }
        return list;
    }
}
