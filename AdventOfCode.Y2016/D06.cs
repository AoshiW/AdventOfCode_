using System.Runtime.InteropServices;

namespace AdventOfCode.Y2016;

public class D06 : IDay<string>
{
    public int Year => 2016;

    public int Day => 6;

    public string Title => "Signals and Noise";

    public string Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        return string.Create(input.Length, input, (s, n) =>
        {
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = n[i].MaxBy(kv => kv.Value).Key;
            }
        });
    }

    static Dictionary<char, int>[] ParseInput(ReadOnlySpan<char> span)
    {
        var input = new Dictionary<char, int>[span.IndexOf('\n')];
        for (var i = 0; i < input.Length; i++)
        {
            input[i] = new();
        }
        foreach (var item in span.EnumerateLines())
        {
            for (int i = 0; i < item.Length; i++)
            {
                ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(input[i], item[i], out _);
                value++;
            }
        }
        return input;
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        return string.Create(input.Length, input, (s, n) =>
        {
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = n[i].MinBy(kv => kv.Value).Key;
            }
        });
    }
}
