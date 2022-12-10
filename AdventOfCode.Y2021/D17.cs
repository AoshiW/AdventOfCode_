using System.Drawing;

namespace AdventOfCode.Y2021;

public class D17 : IDay<int>
{
    public int Year => 2021;

    public int Day => 17;

    public string Title => "Trick Shot";

    public int Part1(ReadOnlySpan<char> span) => AllX(All(span).Max(x => x.Y)).Max();

    static IEnumerable<Point> All(ReadOnlySpan<char> span)
    {
        //target area: x=139..187, y=-148..-89
        var x1 = int.Parse(span[(span.IndexOf('=') + 1)..span.IndexOf('.')]);
        span = span.Slice(span.IndexOf('.') + 2);
        var x2 = int.Parse(span[..span.IndexOf(',')]);
        var y1 = int.Parse(span[(span.IndexOf('=') + 1)..span.IndexOf('.')]);
        var y2 = int.Parse(span.Slice(span.LastIndexOf('.') + 1));
        List<int> x = new(), y = new();
        for (int i = 0; i <= x2; i++)
        {
            if (AllX(i).Any(x => x.IsInRange(x1, x2+1)))
            {
                x.Add(i);
            }
        }
        for (int i = -y1; i >= y1; i--)
        {
            if (AllY(i, y1).Any(x => x.IsInRange(y1, y2 + 1)))
            {
                y.Add(i);
            }
        }
        return Calculate();

        IEnumerable<Point> Calculate()
        {
            foreach (var itemY in y)
            {
                foreach (var itemX in x)
                {
                    var ytep = itemY;
                    var xtep = itemX;
                    var x = itemX;
                    var y = itemY;
                    while (x <= x2 & y >= y1)
                    {
                        if (x.IsInRange(x1, x2+1) && y.IsInRange(y1, y2+1))
                        {
                            yield return new(itemX, itemY);
                            break;
                        }
                        if (xtep != 0)
                            x += --xtep;
                        y += --ytep;
                    }
                }
            }
        }
    }
  
    static IEnumerable<int> AllX(int from)
    {
        var um = 0;
        for (int i = from; i > 0; i--)
        {
            um += i;
            yield return um;
        }
    }

    static IEnumerable<int> AllY(int from, int to)
    {
        var um = 0;
        for (int i = from; i >= to; i--)
        {
            um += i;
            yield return um;
        }
    }

    public int Part2(ReadOnlySpan<char> span) => All(span).Count();
}
