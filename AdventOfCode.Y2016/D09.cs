namespace AdventOfCode.Y2016;

public class D09 : IDay<long>
{
    public int Year => 2016;

    public int Day => 9;

    public string Title => "Explosives in Cyberspace";

    public long Part1(ReadOnlySpan<char> span)
    {
        long c = 0;
        for (int i = 0; i < span.Length; i++)
        {
            if (char.IsWhiteSpace(span[i]))
            { }
            else if (span[i] != '(')
            {
                c++;
            }
            else
            {
                span = span.Slice(i + 1);
                i = span.IndexOf('x');
                int subsequent = int.Parse(span.Slice(0, i));
                span = span.Slice(i + 1);
                i = span.IndexOf(')');
                int repeat = int.Parse(span.Slice(0, i));
                span = span.Slice(i + subsequent);
                i = 0;
                c += subsequent * repeat;
            }
        }
        return c;
    }

    public long Part2(ReadOnlySpan<char> span) => Recursion(span);

    static long Recursion(ReadOnlySpan<char> span)
    {
        long c = 0;
        for (int i = 0; i < span.Length; i++)
        {
            if (char.IsWhiteSpace(span[i]))
            { }
            else if (span[i] != '(')
            {
                c++;
            }
            else
            {
                span = span.Slice(i + 1);
                i = span.IndexOf('x');
                var subsequent = int.Parse(span.Slice(0, i));
                span = span.Slice(i + 1);
                i = span.IndexOf(')');
                var repeat = uint.Parse(span.Slice(0, i));
                c += Recursion(span.Slice(i + 1, subsequent)) * repeat;
                span = span.Slice(i + subsequent);
                i = 0;
            }
        }
        return c;
    }
}
