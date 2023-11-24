using Kunc.AdventOfCode;
using Kunc.AdventOfCode.Utils;

namespace AdventOfCode.Y2018;

public class D03: IDay<int>
{
    public int Year => 2018;
    public string Title => "No Matter How You Slice It";
    public int Day => 3;

    public int Part1(ReadOnlySpan<char> span)
    {
        var fabric = new int[1000, 1000];
        foreach (var line in span.EnumerateLines())
        {
            ParseLine(line, out _, out var r, out var c, out var w, out var h);
            for (int hc = 0; hc < h; hc++)
            {
                for (int wc = 0; wc < w; wc++)
                {
                    fabric[r + wc, c + hc]++;
                }
            }
        }
        return fabric.AsEnumerable().Count(x => x > 1);
    }

    static void ParseLine(ReadOnlySpan<char> line, out int id, out int r, out int c, out int w, out int h)
    {
        line = line.Slice(1);
        id = int.Parse(line.Slice(0, line.IndexOf(' ')));
        line = line.Slice(line.IndexOf("@ ") + 2);
        var i = line.IndexOf(',');
        r = int.Parse(line.Slice(0, i));
        line = line.Slice(i + 1);
        i = line.IndexOf(':');
        c = int.Parse(line.Slice(0, i));
        line = line.Slice(i + 2);
        i = line.IndexOf('x');
        w = int.Parse(line.Slice(0, i));
        h = int.Parse(line.Slice(i + 1));
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var fabric = new List<int>[1000, 1000];
        var ids = new Dictionary<int, bool>();
        foreach (var line in span.EnumerateLines())
        {
            ParseLine(line, out var id, out var r, out var c, out var w, out var h);
            ids.Add(id, false);
            for (int hc = 0; hc < h; hc++)
            {
                for (int wc = 0; wc < w; wc++)
                {
                    var item = fabric[r + wc, c + hc];
                    if (item is null)
                    {
                        fabric[r + wc, c + hc] = item = new();
                    }
                    else
                    {
                        ids[id] = true;
                        foreach (var it in item)
                        {
                            ids[it] = true;
                        }
                    }
                    item.Add(id);
                }
            }
        }
        return ids.First(x => !x.Value).Key;
    }
}
