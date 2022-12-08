namespace AdventOfCode.Y2016;

public class D20 : IDay<uint>
{
    public int Year => 2016;

    public int Day => 20;

    public string Title => "Firewall Rules";

    public uint Part1(ReadOnlySpan<char> span)
    {
        var l = ParseInput(span);
        ulong min = 0;
        while (min >= l[^1].From)
        {
            if (min < l[^1].To + 1)
                min = l[^1].To + 1;
            l.RemoveAt(l.Count - 1);
        }
        return (uint)min;
    }

    static List<(ulong From, ulong To)> ParseInput(ReadOnlySpan<char> span)
    {
        var l = new List<(ulong From, ulong To)>();
        foreach (var item in span.EnumerateLines())
        {
            int i = item.IndexOf('-');
            var from = uint.Parse(item.Slice(0, i));
            var to = uint.Parse(item.Slice(i + 1));
            l.Add((from, to));
        }
        l.Sort((l, r) => r.From.CompareTo(l.From));
        return l;
    }

    public uint Part2(ReadOnlySpan<char> span)
    {
        var l = ParseInput(span);
        ulong current = 0;
        uint allow = 0;
        while (l.Count > 0)
        {
            if (current >= l[^1].From)
            {
                if (current < l[^1].To + 1)
                {
                    current = l[^1].To + 1;
                }
                l.RemoveAt(l.Count - 1);
            }
            else
            {
                allow++;
                current++;
            }
        }
        return allow;
    }
}
