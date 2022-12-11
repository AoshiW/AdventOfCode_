using System.Runtime.InteropServices;

namespace AdventOfCode.Y2020;

public class D06 : IDay<int>
{
    public int Year => 2020;

    public int Day => 6;

    public string Title => "Custom Customs";

    public int Part1(ReadOnlySpan<char> span)
    {
        int sum = 0;
        var set = new HashSet<char>();
        foreach (var item in span.EnumerateLines())
        {
            if (item.Length == 0)
            {
                sum += set.Count;
                set.Clear();
                continue;
            }
            for (int i = 0; i < item.Length; i++)
            {
                set.Add(item[i]);
            }
        }
        return sum + set.Count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var dic = new Dictionary<char, int>();
        int sum = 0, count = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (item.Length == 0)
            {
                EveryoneYes(dic, count, ref sum);
                count = 0;
                dic.Clear();
                continue;
            }
            count++;
            for (int i = 0; i < item.Length; i++)
            {
                ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, item[i], out _);
                value++;
            }
        }

        EveryoneYes(dic, count, ref sum);
        return sum;
    }

    static void EveryoneYes(Dictionary<char, int> dic, int groups, ref int sum)
    {
        foreach (var item in dic)
        {
            if (item.Value == groups)
                sum++;
        }
    }
}
