namespace AdventOfCode.Y2021;

public class D06 : IDay<ulong>
{
    public int Year => 2021;

    public int Day => 6;

    public string Title => "Lanternfish";

    public ulong Part1(ReadOnlySpan<char> span) => Lanternfish(span, 80);

    public ulong Part2(ReadOnlySpan<char> span) => Lanternfish(span, 256);

    static ulong Lanternfish(ReadOnlySpan<char> span, int days)
    {
        Span<ulong> fish = stackalloc ulong[9];
        foreach (var item in span.EnumerateSlices(","))
        {
            fish[int.Parse(item)]++;
        }
        for (int i = 0; i < days; i++)
        {
            var temp = fish[0];
            for (int ii = 0; ii < fish.Length - 1; ii++)
            {
                fish[ii] = fish[ii + 1];
            }
            fish[6] += temp;
            fish[8] = temp;
        }
        var count = 0UL;
        foreach (var item in fish)
        {
            count += item;
        }
        return count;
    }
}
