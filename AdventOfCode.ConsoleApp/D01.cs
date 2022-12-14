namespace AdventOfCode.Y2018;

public sealed class D01 : IDay<int>
{
    public static int Year => 2018;

    public static int Day => 1;

    public static string Title => "Chronal Calibration";

    public int Part1(ReadOnlySpan<char> span)
    {
        int sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            sum += int.Parse(item);
        }
        return sum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        //span = "+1\n-2\n+3\n+1";
        var hs = new HashSet<int>() { 0 };
        int sum = 0;
        while (true)
        {
            foreach (var item in span.EnumerateLines())
            {
                sum += int.Parse(item);
                if (!hs.Add(sum))
                {
                    return sum;
                }
            }
        }
    }
}
