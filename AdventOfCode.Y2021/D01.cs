namespace AdventOfCode.Y2021;

public class D01 : IDay<int>
{
    public int Year => 2021;

    public int Day => 1;

    public string Title => "Sonar Sweep";

    public int Part1(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines(1);
        var last = int.Parse(enumerator.Current);
        int count = 0;
        foreach (var item in enumerator)
        {
            var temp = int.Parse(item);
            if (temp > last)
                count++;
            last = temp;
        }
        return count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        Span<int> buffer = stackalloc int[4];
        var enumerator = span.EnumerateLines();
        for (int i = 0; i < 3; i++)
        {
            enumerator.MoveNext();
            buffer[i] = int.Parse(enumerator.Current);
        }
        int count = 0;
        var sum = buffer[0] + buffer[1] + buffer[2];
        for (int i = 3; enumerator.MoveNext(); i++)
        {
            buffer[i & 3] = int.Parse(enumerator.Current);
            var item = buffer[i & 3] + buffer[(i - 1) & 3] + buffer[(i - 2) & 3];
            if (item > sum)
                count++;
            sum = item;
        }
        return count;
    }
}
