namespace AdventOfCode.Y2022;

public class D06 : IDay<int>
{
    public int Year => 2022;

    public int Day => 6;

    public string Title => "Tuning Trouble";

    public int Part1(ReadOnlySpan<char> span) => StartOfX(span, 4); // packet

    public int Part2(ReadOnlySpan<char> span) => StartOfX(span, 14); // message

    static int StartOfX(ReadOnlySpan<char> span, int count)
    {
        for (int i = count; i < span.Length; i++)
        {
            var allDiff = true;
            var item = span.Slice(i - count, count);
            for (int i2 = 1; i2 < item.Length; i2++)
            {
                if (item.Slice(i2).Contains(item[i2 - 1]))
                {
                    allDiff = false;
                    break;
                }
            }
            if (allDiff)
                return i;
        }
        return -1;
    }
}
