using System.Numerics;
using System.Runtime.InteropServices;

namespace AdventOfCode.Y2015;

public class D24 : IDay<long>
{
    public int Year => 2015;

    public int Day => 24;

    public string Title => "It Hangs in the Balance";

    public long Part1(ReadOnlySpan<char> span)
    {
        var data = ParseInput(span);
        var av = data.Sum() / 3;
        var dataSpan = CollectionsMarshal.AsSpan(data);
        List<int> candidate = new();
        BigInteger QE = 0;
        var c = new List<int>();
        for (int i = IndexWhneGreater(dataSpan, av); i < 1 << dataSpan.Length; i++)
        {
            c.Clear();
            var sum = 0;
            for (int dsi = 0; dsi < dataSpan.Length; dsi++)
            {
                int cindex = 1 << dsi;
                if ((i & cindex) != 0)
                {
                    c.Add(dataSpan[dsi]);
                    sum += dataSpan[dsi];
                    if (sum > av || (candidate.Count != 0 && c.Count > candidate.Count))
                        goto Next;
                }
            }
            if (sum == av)
            {
                var testData = data.Except(c).ToList();
                BigInteger qe = default;
                if ((candidate.Count == 0 || candidate.Count > c.Count || QE > (qe = c.AsReadOnlySpan().Aggregate(BigInteger.One, (p, c) => p * c))) && Calculate(CollectionsMarshal.AsSpan(testData), av))
                {
                    (candidate, c) = (c, candidate);
                    QE = qe == default ? c.AsReadOnlySpan().Aggregate(BigInteger.One, (p, c) => p * c) : qe;
                }
            }
        Next:;
        }
        return (long)QE;
    }

    static int IndexWhneGreater(ReadOnlySpan<int> span, int value)
    {
        var sum = 0;
        var v = 1;
        foreach (var item in span)
        {
            sum += item;
            if (sum > value)
                return v;
            v = (v << 1) + 1;
        }
        return v;
    }

    static bool Calculate(ReadOnlySpan<int> span, int av)
    {
        for (int i = 1; i < 1 << span.Length; i++)
        {
            var sum = 0;
            var sum2 = 0;
            for (int dsi = 0; dsi < span.Length; dsi++)
            {
                int cindex = 1 << dsi;
                if ((i & cindex) != 0)
                {
                    sum += span[dsi];
                }
                else
                {
                    sum2 += span[dsi];
                }
                if (sum > av || sum2 > av)
                    break;
            }
            if (sum == av && sum2 == av)
                return true;
        }
        return false;
    }

    static List<int> ParseInput(ReadOnlySpan<char> span)
    {
        var data = new List<int>(16);
        foreach (var item in span.EnumerateLines())
        {
            data.Add(int.Parse(item, null));
        }
        return data;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
    }
}
