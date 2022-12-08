namespace AdventOfCode.Y2016;

public class D18 : IDay<int>
{
    public int Year => 2016;

    public int Day => 18;

    public string Title => "Like a Rogue";

    public int Part1(ReadOnlySpan<char> span) => SafeTiles(span, 40);

    static int SafeTiles(ReadOnlySpan<char> span, int rowC)
    {
        Span<char> curr = stackalloc char[span.Length];
        Span<char> last = stackalloc char[span.Length];
        span.CopyTo(last);
        int count = 0;
        for (int i = 0; i < last.Length; i++)
        {
            if (last[i] == '.')
                count++;
        }
        for (int r = 1; r < rowC; r++)
        {
            if (last[1] == '^')
            {
                curr[0] = '^';
            }
            else
            {
                curr[0] = '.';
                count++;
            }
            for (int c = 1; c < span.Length - 1; c++)
            {
                if (last[c - 1] == '^' && last[c + 1] == '.' || last[c + 1] == '^' && last[c - 1] == '.')
                {
                    curr[c] = '^';
                }
                else
                {
                    curr[c] = '.';
                    count++;
                }
            }
            if (last[^2] == '^')
            {
                curr[^1] = '^';
            }
            else
            {
                curr[^1] = '.';
                count++;
            }
            curr.CopyTo(last);
        }
        return count;
    }
    public int Part2(ReadOnlySpan<char> span) => SafeTiles(span, 400_000);
}
