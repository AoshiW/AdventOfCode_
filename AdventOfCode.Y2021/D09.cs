using System.Drawing;

namespace AdventOfCode.Y2021;
public class D09 : IDay<int>
{
    public int Year => 2021;

    public int Day => 9;

    public string Title => "Smoke Basin";

    public int Part1(ReadOnlySpan<char> span)
    {
        var sum = 0;
        var map = new List<char[]>();
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToArray());
        }
        foreach (var point in GetPointEnumerator(map))
        {
            var isNotBreak = true;
            foreach (var item in MagicNumbers.Offset4)
            {
                var newPoint = point + item;
                if (newPoint.X >= 0 && newPoint.Y >= 0 && newPoint.X < map.Count && newPoint.Y < map[0].Length && map[point.X][point.Y] >= map[newPoint.X][newPoint.Y])
                {
                    isNotBreak = false;
                    break;
                }
            }
            if (isNotBreak)
            {
                sum += (int)char.GetNumericValue(map[point.X][point.Y]) + 1;
            }
        }
        return sum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var map = new List<char[]>();
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToArray());
        }
        Span<int> max = stackalloc int[3];
        foreach (var point in GetPointEnumerator(map))
        {
            if (map[point.X][point.Y] != '9')
            {
                var val = GetBasinSize(point, map);
                if (val > max[0])
                {
                    max[0] = val;
                    max.Sort();
                }
            }
        }
        return max[0] * max[1] * max[2];
    }

    static int GetBasinSize(Point point, List<char[]> map)
    {
        var sum = 0;
        var tack = new Stack<Point>();
        tack.Push(point);
        while (tack.TryPop(out point))
        {
            foreach (var item in MagicNumbers.Offset4)
            {
                var newPoint = point + item;
                if (newPoint.X >= 0 && newPoint.Y >= 0 && newPoint.X < map.Count && newPoint.Y < map[0].Length && map[newPoint.X][newPoint.Y] != '9')
                {
                    sum++;
                    tack.Push(newPoint);
                    map[newPoint.X][newPoint.Y] = '9';
                }
            }
        }
        return sum;
    }

    static IEnumerable<Point> GetPointEnumerator(List<char[]> map)
    {
        var p = new Point();
        for (; p.Y < map.Count; p.Y++)
        {
            for (p.X = 0; p.X < map[0].Length; p.X++)
            {
                yield return p;
            }
        }
    }
}
