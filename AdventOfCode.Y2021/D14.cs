using System.Runtime.InteropServices;

namespace AdventOfCode.Y2021;

public class D14 : IDay<ulong>
{
    public int Year => 2021;

    public int Day => 14;

    public string Title => "Extended Polymerization";

    public ulong Part1(ReadOnlySpan<char> span) => PolymerProcess(span, 10);

    public ulong Part2(ReadOnlySpan<char> span) => PolymerProcess(span, 40);

    static ulong PolymerProcess(ReadOnlySpan<char> span, int steps)
    {
        var enumerator = span.EnumerateLines(1);
        var polymer = enumerator.Current;
        enumerator.MoveNext();
        var dic = new Dictionary<char, ulong>();
        var rules = new Dictionary<(char, char), char>();
        var poli = new Dictionary<(char, char), ulong>();
        while (enumerator.MoveNext())
        {
            rules[(enumerator.Current[0], enumerator.Current[1])] = enumerator.Current[^1];
            dic[enumerator.Current[^1]] = 0;
        }
        dic[polymer[0]]++;
        for (int i = 1; i < polymer.Length; i++)
        {
            dic[polymer[i]]++;
            var k = (polymer[i - 1], polymer[i]);
            ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(poli, k, out _);
            value++;
        }

        var temp = new Dictionary<(char, char), ulong>();
        while (steps-- > 0)
        {
            foreach (var item in poli)
            {
                var fin = rules[item.Key];
                dic[fin] += item.Value;

                var k = (item.Key.Item1, fin);
                ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(temp, k, out var exists);
                value = exists ? value + item.Value : item.Value;

                k = (fin, item.Key.Item2);
                value = ref CollectionsMarshal.GetValueRefOrAddDefault(temp, k, out exists);
                value = exists ? value + item.Value : item.Value;
            }
            (temp, poli) = (poli, temp);
            temp.Clear();
        }
        return dic.MaxBy(x => x.Value).Value - dic.MinBy(x => x.Value).Value;
    }
}
