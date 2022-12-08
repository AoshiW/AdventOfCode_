namespace AdventOfCode.Y2016;

public class D03 : IDay<int>
{
    public int Year => 2016;

    public int Day => 3;

    public string Title => "Squares With Three Sides";

    public int Part1(ReadOnlySpan<char> span)
    {
        int c = 0;
        Span<int> num = stackalloc int[3];
        foreach (var item in span.EnumerateLines())
        {
            ParseLine(item, num);
            if (num[0] + num[1] > num[2] &&
                num[1] + num[2] > num[0] &&
                num[2] + num[0] > num[1])
                c++;
        }
        return c;
    }

    static void ParseLine(ReadOnlySpan<char> span, Span<int> values)
    {
        var enumerator = span.EnumerateSlices(" ");
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            values[i] = int.Parse(enumerator.Current);
        }
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int c = 0;
        var enumerator = span.EnumerateLines();
        Span<int> n0 = stackalloc int[3];
        Span<int> n1 = stackalloc int[3];
        Span<int> n2 = stackalloc int[3];
        while (enumerator.MoveNext())
        {
            ParseLine(enumerator.Current, n0);
            enumerator.MoveNext();
            ParseLine(enumerator.Current, n1);
            enumerator.MoveNext();
            ParseLine(enumerator.Current, n2);
            for (int ii = 0; ii < 3; ii++)
            {
                if (n0[ii] + n1[ii] > n2[ii] &&
                    n1[ii] + n2[ii] > n0[ii] &&
                    n2[ii] + n0[ii] > n1[ii])
                    c++;
            }
        }
        return c;
    }
}
