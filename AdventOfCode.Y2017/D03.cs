using System.Drawing;

namespace AdventOfCode.Y2017;

public class D03 : IDay<int>
{
    public int Year => 2017;

    public int Day => 3;

    public string Title => "Spiral Memory";

    public int Part1(ReadOnlySpan<char> span)
    {
        var num = int.Parse(span) - 1;
        int direction = 0;
        var point = new Point();
        foreach (var item in SpiralFullLength())
        {
            switch (direction)
            {
                case 0:
                    point.X += item;
                    break;
                case 1:
                    point.Y += item;
                    break;
                case 2:
                    point.X -= item;
                    break;
                case 3:
                    point.Y -= item;
                    break;
            }
            num -= item;
            if (num <= 0)
            {
                switch (direction)
                {
                    case 0:
                        point.X += num;
                        break;
                    case 1:
                        point.Y += num;
                        break;
                    case 2:
                        point.X -= num;
                        break;
                    case 3:
                        point.Y -= num;
                        break;
                }
                break;
            }
            direction = (direction + 1) % 4;
        }
        return Point.Empty.GetManhattanDistance(point);
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var num = int.Parse(span);
        return SpiralSum().First(x => x > num);
    }

    static IEnumerable<int> SpiralFullLength()
    {
        int i = 0;
        while (true)
        {
            yield return ++i;
            yield return i;
        }
    }

    static IEnumerable<int> SpiralSum()
    {
        int direction = 0;
        var point = new Point();
        var cache = new Dictionary<Point, int>()
        {
            { Point.Empty, 1 }
        };
        var offset = MagicNumbers.Offset8.ToArray();
        foreach (var item in SpiralFullLength())
        {
            for (int i = 0; i < item; i++)
            {
                switch (direction)
                {
                    case 0:
                        point.X++;
                        break;
                    case 1:
                        point.Y++;
                        break;
                    case 2:
                        point.X--;
                        break;
                    case 3:
                        point.Y--;
                        break;
                }
                int sum = 0;
                foreach (var os in offset)
                {
                    sum += cache.TryGetValue(point + os, out var value) ? value : 0;
                }
                cache[point] = sum;
                yield return sum;
            }
            direction = (direction + 1) % 4;
        }
    }
}
