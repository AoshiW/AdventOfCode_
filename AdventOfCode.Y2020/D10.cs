using System.Runtime.InteropServices;

namespace AdventOfCode.Y2020;

public class D10 : IDay<long>
{
    public int Year => 2020;

    public int Day => 10;

    public string Title => "Adapter Array";

    public long Part1(ReadOnlySpan<char> span)
    {
        var adapters = ParseInput(span);
        adapters.Insert(0, 0);
        adapters.Sort();
        adapters.Add(adapters[^1] + 3);
        int o = 0, t = 0;
        for (int i = 0; i < adapters.Count - 1; i++)
        {
            if (adapters[i] + 1 == adapters[i + 1])
            {
                o++;
            }
            else if (adapters[i] + 3 == adapters[i + 1])
            {
                t++;
            }
            else
                throw new ArgumentException(null, nameof(span));
        }
        return o * t;
    }

    static List<int> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<int>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(int.Parse(item));
        }
        return list;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        var adapters = ParseInput(span);
        adapters.Insert(0, 0);
        adapters.Sort();
        adapters.Add(adapters[^1] + 3);
        var sum = 1L;
        var adaptersSpan = CollectionsMarshal.AsSpan(adapters);
        for (int i = 0, io = 0; i + 1 < adapters.Count; i++)
        {
            if (adapters[1 + i] - adapters[i] == 3)
            {
                var subAdapters = adaptersSpan.Slice(io, ++i - io);
                sum *= CalculateNumberOfOptions(subAdapters);
                io = i;
            }
        }
        return sum;
    }

    static long CalculateNumberOfOptions(ReadOnlySpan<int> adapters)
    {
        if (adapters.Length  == 1)
            return 1;
        var sum = 0L;
        for (int i = 0; i < 3 && i + 1 < adapters.Length; i++)
        {
            if (adapters[1 + i] - adapters[0] is 1 or 2 or 3)
            {
                sum += CalculateNumberOfOptions(adapters.Slice(1 + i));
            }
        }
        return sum;
    }
}
