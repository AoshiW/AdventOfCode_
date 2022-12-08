namespace AdventOfCode.Y2015;

public class D06 : IDay<int>
{
    public int Year => 2015;

    public int Day => 6;

    public string Title => "Probably a Fire Hazard";

    public int Part1(ReadOnlySpan<char> span)
    {
        var grid = new bool[1000, 1000];
        foreach (var item in span.EnumerateLines())
        {
            ParseInput(item, out var x1, out var y1, out var x2, out var y2);
            while (x1++ <= x2)
            {
                for (var y3 = y1; y3 <= y2; y3++)
                {
                    grid[y3, x1] = item[6] != 'f' && (item[6] == 'n' || !grid[y3, x1]);
                    //grid[y3, x1] = item[6] == 'f' ? false : item[6] == 'n' ? true : !grid[y3, x1];
                }
            }
        }
        return grid.Count(static x => x);
    }

    static void ParseInput(ReadOnlySpan<char> span, out int x1, out int y1, out int x2, out int y2)
    {
        Span<int> indexes = stackalloc int[4];
        var index = span.IndexOf(',');
        for (int i = 0, valuesI = 0; i < span.Length; i++)
        {
            if (span[i].Equals(' '))
            {
                indexes[valuesI++] = i;
            }
        }
        if (span[4] == ' ')
        {
            x1 = int.Parse(span.Slice(indexes[1] + 1, index - 1 - indexes[1]));
            y1 = int.Parse(span.Slice(index + 1, indexes[2] - 1 - index));
        }
        else
        {
            x1 = int.Parse(span.Slice(indexes[0] + 1, index - 1 - indexes[0]));
            y1 = int.Parse(span.Slice(index + 1, indexes[1] - 1 - index));
        }
        index = span.LastIndexOf(',');
        var tempindex = indexes[^1] == default ? indexes[^2] : indexes[^1];
        x2 = int.Parse(span.Slice(tempindex + 1, index - tempindex - 1));
        y2 = int.Parse(span.Slice(index + 1));
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var grid = new int[1000, 1000];
        foreach (var item in span.EnumerateLines())
        {
            ParseInput(item, out var x1, out var y1, out var x2, out var y2);
            while (x1++ <= x2)
            {
                for (var y3 = y1; y3 <= y2; y3++)
                {
                    grid[y3, x1] += item[6] == 'f' 
                        ? grid[y3, x1] == 0 ? 0 : -1 
                        : item[6] == 'n' ? 1 : 2;
                }
            }
        }
        return grid.Sum();
    }
}
