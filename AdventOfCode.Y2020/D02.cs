namespace AdventOfCode.Y2020;

public class D02 : IDay<int>
{
    public int Year => 2020;

    public int Day => 2;

    public string Title => "Password Philosophy";

    public int Part1(ReadOnlySpan<char> span)
    {
        int count = 0;
        foreach (var item in span.EnumerateLines())
        {
            ParseLine(item, out var n1, out var n2, out var c, out var password);
            var n = password.Count(x => x == c);
            if (n1 <= n && n <= n2)
                count++;
        }
        return count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int count = 0;
        foreach (var item in span.EnumerateLines())
        {
            ParseLine(item, out var n1, out var n2, out var c, out var password);
            n1--;
            n2--;
            if (password[n1] == c && password[n2] != c || password[n1] != c && password[n2] == c)
                count++;
        }
        return count;
    }

    static void ParseLine(ReadOnlySpan<char> span, out int num1, out int num2, out char c, out ReadOnlySpan<char> password)
    {
        var i = span.IndexOf('-');
        num1 = int.Parse(span.Slice(0, i));
        span = span.Slice(i + 1);
        i = span.IndexOf(' ');
        num2 = int.Parse(span.Slice(0, i));
        span = span.Slice(i + 1);
        c = span[0];
        password = span.Slice(3);
    }
}
