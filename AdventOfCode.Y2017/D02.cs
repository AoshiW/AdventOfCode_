namespace AdventOfCode.Y2017;

public class D02 : IDay<int>
{
    public int Year => 2017;

    public int Day => 2;

    public string Title => "Corruption Checksum";

    public int Part1(ReadOnlySpan<char> span)
    {
        var sum = 0;
        foreach (var line in span.EnumerateLines())
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var item in line.EnumerateSlices(" \t"))
            {
                var num = int.Parse(item);
                if (num > max)
                    max = num;
                if (num < min)
                    min = num;
            }
            sum += max - min;
        }
        return sum;
    }

    /// <inheritdoc/>
    public int Part2(ReadOnlySpan<char> span)
    {
        var sum = 0;
        foreach (var line in span.EnumerateLines())
        {
            var list = new List<int>();
            foreach (var item in line.EnumerateSlices(" \t"))
            {
                list.Add(int.Parse(item));
            }
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                for (int i2 = 0; i2 < list.Count; i2++)
                {
                    if (i1 == i2)
                        continue;
                    var n1 = list[i1];
                    var n2 = list[i2];
                    if (n1 % n2 == 0)
                    {
                        sum += n1 / n2;
                        i1 = list.Count;
                        break;
                    }
                    else if (n2 % n1 == 0)
                    {
                        sum += n2 / n1;
                        i1 = list.Count;
                        break;
                    }
                }
            }
        }
        return sum;
    }
}
