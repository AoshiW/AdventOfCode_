using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017;

public class D06 : IDay<int>
{
    public int Year => 2017;

    public int Day => 6;

    public string Title => "Memory Reallocation";

    public int Part1(ReadOnlySpan<char> span) => T(span).Steps;

    public int Part2(ReadOnlySpan<char> span) => T(span).Diff;

    static (int Steps, int Diff) T(ReadOnlySpan<char> span)
    {
        var memory = new List<int>();
        var history = new Dictionary<ulong, int>();
        foreach (var item in span.EnumerateSlices("\t"))
        {
            memory.Add(int.Parse(item));
        }
        int steps = 0;

        while (true)
        {
            var hash = memory.Aggregate(0ul, (a, i) => (a << 4) | (uint)i);
            ref int value = ref CollectionsMarshal.GetValueRefOrAddDefault(history, hash, out var exist);
            if (exist)
                return (steps, steps - value);
            value = steps;

            var max = memory.Max();
            var index = memory.IndexOf(max);
            memory[index] = 0;
            while (max-- > 0)
            {
                index = ++index % memory.Count;
                memory[index]++;
            }
            steps++;
        }
    }
}
