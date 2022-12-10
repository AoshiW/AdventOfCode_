using System.Drawing;

namespace AdventOfCode.Y2022;

public class D09 : IDay<int>
{
    public int Year => 2022;

    public string Title => "Rope Bridge";

    public int Day => 9;

    public int Part1(ReadOnlySpan<char> span) => Core(span, 2);

    static int Core(ReadOnlySpan<char> span, int knotsCount)
    {
        var history = new HashSet<Point> { default };
        Span<Point> knots = stackalloc Point[knotsCount];
        foreach (var item in span.EnumerateLines())
        {
            var num = int.Parse(item.Slice(item.IndexOf(' ') + 1));
            for (int i = 0; i < num; i++)
            {
                switch (item[0])
                {
                    case 'U': knots[0].Y++; break;
                    case 'D': knots[0].Y--; break;
                    case 'L': knots[0].X--; break;
                    case 'R': knots[0].X++; break;
                }
                for (int ii = 1; ii < knots.Length; ii++)
                {
                    var head = knots[ii - 1];
                    ref var tail = ref knots[ii];

                    var xDiff = head.X - tail.X;
                    var yDiff = head.Y - tail.Y;
                    if (Math.Abs(xDiff) <= 1 && Math.Abs(yDiff) <= 1)
                    {
                        continue;
                    }
                    if (xDiff == 2) xDiff--;
                    if (xDiff == -2) xDiff++;

                    if (yDiff == 2) yDiff--;
                    if (yDiff == -2) yDiff++;

                    tail.X += xDiff;
                    tail.Y += yDiff;
                }
                history.Add(knots[^1]);
            }
        }
        return history.Count;
    }

    public int Part2(ReadOnlySpan<char> span) => Core(span, 10);
}
