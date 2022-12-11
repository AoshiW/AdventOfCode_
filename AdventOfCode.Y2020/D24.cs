using System.Drawing;

namespace AdventOfCode.Y2020;

public class D24 : IDay<int>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 24;

    /// <inheritdoc/>
    public string Title => "Lobby Layout";

    /// <inheritdoc/>
    public int Part1(ReadOnlySpan<char> span)
    {
        return Init(span).Count;
    }

    static HashSet<PointF> Init(ReadOnlySpan<char> span)
    {
        var black = new HashSet<PointF>();
        foreach (var item in span.EnumerateLines())
        {
            var point = new PointF();
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == 'e')
                {
                    point.X++;
                    continue;
                }
                else if (item[i] == 'w')
                {
                    point.X--;
                    continue;
                }
                else if (item[i] == 's')
                {
                    point.Y--;
                }
                else if (item[i] == 'n')
                {
                    point.Y++;
                }
                i++;
                if (item[i] == 'e')
                {
                    point.X += 0.5f;
                }
                else if (item[i] == 'w')
                {
                    point.X -= 0.5f;
                }
            }
            if (!black.Add(point))
            {
                black.Remove(point);
            }
        }
        return black;
    }

    /// <inheritdoc/>
    public int Part2(ReadOnlySpan<char> span)
    {
        var black = Init(span);
        var temp = new HashSet<PointF>();
        for (int i = 0; i < 100; i++)
        {
            foreach (var point in black)
            {
                var c = Check(black, point);
                if (c is 1 or 2)
                {
                    temp.Add(point);
                }
                foreach (var item in NearbyPoints)
                {
                    c = 0;
                    var whitePoint = new PointF(point.X + item.X, point.Y + item.Y);
                    if (!black.Contains(whitePoint))
                    {
                        c = Check(black, whitePoint);
                        if (c == 2)
                            temp.Add(whitePoint);
                    }
                }
            }
            var t = temp;
            temp = black;
            black = t;
            temp.Clear();
        }
        return black.Count;
    }

    static readonly PointF[] NearbyPoints =
    {
        new(1, 0),
        new(-1, 0),
        new(0.5f, 1),
        new(0.5f, -1),
        new(-0.5f, 1),
        new(-0.5f, -1)
    };

    static int Check(HashSet<PointF> source, PointF point)
    {
        int count = 0;
        foreach (var item in NearbyPoints)
        {
            if (source.Contains(new(point.X + item.X, point.Y + item.Y)))
            {
                count++;
            }
        }
        return count;
    }
}
