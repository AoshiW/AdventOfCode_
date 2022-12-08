using System.Drawing;

namespace AdventOfCode.Y2016;

public class D01 : IDay<int>
{
    public int Year => 2016;

    public int Day => 1;

    public string Title => "No Time for a Taxicab";

    public int Part1(ReadOnlySpan<char> span)
    {
        int a = 0;
        var p = new Point();
        foreach (var item in span.EnumerateSlices(" ,"))
        {
            var m = int.Parse(item.Slice(1));
            a = (a + (item[0] == 'R' ? 90 : -90)) % 360;
            if (a < 0)
                a += 360;
            switch (a)
            {
                case 0: p.X += m; break;
                case 180: p.X -= m; break;
                case 90: p.Y += m; break;
                case 270: p.Y -= m; break;
            }
        }
        return Math.Abs(p.X) + Math.Abs(p.Y);
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var history = new HashSet<Point>();
        int a = 0;
        var p = new Point();
        foreach (var item in span.EnumerateSlices(" ,"))
        {
            var m = int.Parse(item.Slice(1));
            a = (a + (item[0] == 'R' ? 90 : -90)) % 360;
            if (a < 0)
                a += 360;
            switch (a)
            {
                case 0:
                    for (int i = 0; i < m; i++)
                    {
                        p.X++;
                        if (!history.Add(p))
                            return Math.Abs(p.X) + Math.Abs(p.Y);
                    }
                    break;
                case 180:
                    for (int i = 0; i < m; i++)
                    {
                        p.X--;
                        if (!history.Add(p))
                            return Math.Abs(p.X) + Math.Abs(p.Y);
                    }
                    break;
                case 90:
                    for (int i = 0; i < m; i++)
                    {
                        p.Y++;
                        if (!history.Add(p))
                            return Math.Abs(p.X) + Math.Abs(p.Y);
                    }
                    break;
                case 270:
                    for (int i = 0; i < m; i++)
                    {
                        p.Y--;
                        if (!history.Add(p))
                            return Math.Abs(p.X) + Math.Abs(p.Y);
                    }
                    break;
            }
        }
        throw new ArgumentException(null, nameof(span));
    }
}
