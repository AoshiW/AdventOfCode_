namespace AdventOfCode.Y2020;

public class D05 : IDay<int>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 5;

    /// <inheritdoc/>
    public string Title => "Binary Boarding";

    /// <inheritdoc/>
    public int Part1(ReadOnlySpan<char> span)
    {
        int min, max, id, idM = 0, r, l, tmp;
        foreach (var item in span.EnumerateLines())
        {
            r = min = 0;
            max = 127;
            l = 7;
            for (int row = 0; row < item.Length - 3; row++)
            {
                tmp = (int)Math.Round((max - min) / 2.0, MidpointRounding.AwayFromZero); ;
                if (item[row] == 'F')
                {
                    max -= tmp;
                }
                else
                {
                    min += tmp;
                }
            }

            for (int row = 7; row < item.Length; row++)
            {
                tmp = (int)Math.Round((r - l) / 2.0, MidpointRounding.AwayFromZero);
                if (item[row] == 'R')
                {
                    r -= tmp;
                }
                else
                {
                    l += tmp;
                }
            }
            id = min * 8 + r;
            if (idM < id)
                idM = id;
        }
        return idM;
    }

    /// <inheritdoc/>
    public int Part2(ReadOnlySpan<char> span)
    {
        var k = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            k.Add(i);
        }
        int min, max, id, idM = 0, r, l, tmp;
        foreach (var item in span.EnumerateLines())
        {
            r = min = 0;
            max = 127;
            l = 7;
            for (int row = 0; row < item.Length - 3; row++)
            {
                tmp = (int)Math.Round((max - min) / 2.0, MidpointRounding.AwayFromZero); ;
                if (item[row] == 'F')
                {
                    max -= tmp;
                }
                else
                {
                    min += tmp;
                }
            }
            for (int row = 7; row < item.Length; row++)
            {
                tmp = (int)Math.Round((r - l) / 2.0, MidpointRounding.AwayFromZero);
                if (item[row] == 'R')
                {
                    r -= tmp;
                }
                else
                {
                    l += tmp;
                }
            }
            id = max * 8 + r;
            k.Remove(id);
            if (idM < id)
                idM = id;
        }
        return k.First(x => !k.Contains(x - 1) && !k.Contains(x + 1));
    }
}
