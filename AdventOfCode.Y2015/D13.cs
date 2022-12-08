using System.Runtime.InteropServices;

namespace AdventOfCode.Y2015;

public class D13 : IDay<int>
{
    public int Year => 2015;

    public int Day => 13;

    public string Title => "Knights of the Dinner Table";

    public int Part1(ReadOnlySpan<char> span) => TotalChangeInHappiness(span, false);

    public int Part2(ReadOnlySpan<char> span) => TotalChangeInHappiness(span, true);

    static int TotalChangeInHappiness(ReadOnlySpan<char> span, bool addMe)
    {
        var dic = new Dictionary<string, Dictionary<string, int>>();
        foreach (var item in span.EnumerateLines())
        {
            var from = item.Slice(0, item.IndexOf(' ')).ToString();
            var to = item.Slice(item.LastIndexOf(" ") + 1).TrimEnd('.').ToString();
            var value = item.Contains(" lose ", StringComparison.OrdinalIgnoreCase) ? -1 : 1;
            var item2 = item.Slice(0, item.IndexOf(" happiness "));
            value *= int.Parse(item2.Slice(item2.LastIndexOf(' ') + 1));
            ref var innerDic = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, from, out var isInnerDic);
            if (!isInnerDic)
                innerDic = new();
            innerDic![to.ToString()] = value;
        }
        if (addMe)
            dic["me"] = new();

        var max = 0;
        foreach (ReadOnlySpan<string> item in HeapPermutation(dic.Keys.ToArray(), dic.Keys.Count))
        {
            int sum = dic[item[^1]].GetValueOrDefault(item[0]) +
                dic[item[0]].GetValueOrDefault(item[^1]);
            for (int i = 1; i < item.Length; i++)
            {
                sum += dic[item[i - 1]].GetValueOrDefault(item[i]) +
                    dic[item[i]].GetValueOrDefault(item[i - 1]);
            }
            if (sum > max)
                max = sum;
        }
        return max;
    }

    // https://www.geeksforgeeks.org/heaps-algorithm-for-generating-permutations/
    static IEnumerable<T[]> HeapPermutation<T>(T[] a, int size)
    {
        if (size == 1)
            yield return a;

        for (int i = 0; i < size; i++)
        {
            foreach (var item in HeapPermutation(a, size - 1))
            {
                yield return item;
            }
            if ((size & 1) == 1)
            {
                (a[size - 1], a[0]) = (a[0], a[size - 1]);
            }
            else
            {
                (a[size - 1], a[i]) = (a[i], a[size - 1]);
            }
        }
    }
}
