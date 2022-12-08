namespace AdventOfCode.Y2015;

public class D02 : IDay<int>
{
    public int Year => 2015;

    public int Day => 2;

    public string Title => "I Was Told There Would Be No Math";

    public int Part1(ReadOnlySpan<char> span)
    {
        var sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            ParseLine(item, out var l, out var w, out var h);
            var min = Math.Min(l, Math.Min(w, h));
            var max = Math.Max(l, Math.Max(w, h));
            sum += 2 * (w * (l + h) + h * l) + min * (l + w + h - min - max);
        }
        return sum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            ParseLine(item, out var l, out var w, out var h);
            var max = Math.Max(l, Math.Max(w, h));
            sum += l * w * h + 2 * (l + w + h - max);
        }
        return sum;
    }

    static void ParseLine(ReadOnlySpan<char> span, out int length, out int width, out int height)
    {
        var first = span.IndexOf('x');
        var last = span.LastIndexOf('x');
        length = int.Parse(span.Slice(0, first));
        width = int.Parse(span.Slice(first + 1, last - first - 1));
        height = int.Parse(span.Slice(last + 1));
    }
}
