namespace AdventOfCode.Y2015;

public class D25 : IDay<long>
{
    public int Year => 2015;

    public int Day => 25;

    public string Title => "Let It Snow";

    public long Part1(ReadOnlySpan<char> span)
    {
        ParseInput(span, out var row, out var column);
        var number = 20151125L;
        for (int l = 2; ; l++)
        {
            for (int r = l, c = 1; r > 0; r--, c++)
            {
                number = number * 252533L % 33554393L;
                if (r == row && c == column)
                {
                    return number;
                }
            }
        }
    }

    static void ParseInput(ReadOnlySpan<char> span, out int row, out int column)
    {
        int i = span.Slice(0, span.LastIndexOf(',')).LastIndexOf(' ') + 1;
        var span1 = span.Slice(i, span.LastIndexOf(',') - i);
        i = span.LastIndexOf(' ') + 1;
        var span2 = span.Slice(i, span.LastIndexOf('.') - i);

        row = int.Parse(span1);
        column = int.Parse(span2);
    }

    public long Part2(ReadOnlySpan<char> span) => default;
}
