namespace AdventOfCode.Y2015;

public class D01 : IDay<int>
{
    public int Year => 2015;

    public int Day => 1;

    public string Title => "Not Quite Lisp";

    public int Part1(ReadOnlySpan<char> span)
    {
        return span.Length - span.Count(')') * 2;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        for (int i = 0, florr = 0; i < span.Length; i++)
        {
            florr += span[i] == '(' ? 1 : -1;
            if (florr == -1)
                return i + 1;
        }
        return -1;
    }
}
