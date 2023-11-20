using Kunc.AdventOfCode;
using System.Runtime.InteropServices;

namespace AdventOfCode.Y2018;

public sealed class D02 : IDay<string>
{
    public int Year => 2018;

    public int Day => 2;

    public string Title => "Inventory Management System";

    public string Part1(ReadOnlySpan<char> span)
    {
        int two = 0;
        int three = 0;
        foreach (var item in span.EnumerateLines())
        {
            var group = item.ToString().GroupBy(x => x);
            if(group.Any(x=>x.Count() == 2))
                two++;
            if(group.Any(x=>x.Count() == 3))
                three++;
        }
        return (two * three).ToString();
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var data = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            data.Add(item.ToString());
        }
        var dataspan = CollectionsMarshal.AsSpan(data);
        for (int i = 0; i < dataspan.Length; i++)
        {
            var item = dataspan[i];
            for (int i2 = i+1; i2 < dataspan.Length; i2++)
            {
                if (OneDiff(item, dataspan[i2], out var diffIndex))
                    return item.Remove(diffIndex, 1);
            }
        }
        throw new ArgumentException();
    }

    static bool OneDiff(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2, out int diffIndex)
    {
        diffIndex = -1;
        int difCount = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                difCount++;
                if (difCount == 2)
                    return false;
                diffIndex = i;
            }
        }
        return difCount == 1;
    }
}
