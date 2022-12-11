using System.Runtime.InteropServices;

namespace AdventOfCode.Y2020;

public class D15 : IDay<int>
{
    public int Year => 2020;

    public int Day => 15;

    public string Title => "Rambunctious Recitation";

    public int Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        for (int i = input.Count; i < 2020; i++)
        {
            var turnInex = input.LastIndexOf(input[i - 1], i - 2);
            input.Add(turnInex == -1 ? 0 : i - turnInex - 1);
        }
        return input[^1];
    }

    static List<int> ParseInput(ReadOnlySpan<char> span)
    {
        var result = new List<int>();

        foreach (var item in span.EnumerateSlices(","))
        {
            result.Add(int.Parse(item));
        }
        return result;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < input.Count - 1; i++)
        {
            dic.Add(input[i], i + 1);
        }
        var lastValue = input[^1];
        for (int i = input.Count; i < 30_000_000; i++)
        {
            ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, lastValue, out var exists);
            lastValue = exists ? i - value : 0;
            value = i;
        }
        return lastValue;
    }
}
