namespace AdventOfCode.Y2017;

public class D01 : IDay<int>
{
    public int Year => 2017;

    public int Day => 1;

    public string Title => "Inverse Captcha";

    public int Part1(ReadOnlySpan<char> span)
    {
        var count = span[0] == span[^1] ? span[0] - '0' : 0;
        for (int i = 0; i < span.Length - 1; i++)
        {
            if (span[i] == span[i + 1])
                count += span[i] - '0';
        }
        return count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var half = span.Length / 2;
        var count = 0;
        for (int i = 0; i < span.Length; i++)
        {
            if (span[i] == span[(i + half) % span.Length])
                count += span[i] - '0';
        }
        return count;
    }
}
