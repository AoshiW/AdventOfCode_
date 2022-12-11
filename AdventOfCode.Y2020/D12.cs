using System.Drawing;

namespace AdventOfCode.Y2020;

public class D12 : IDay<int>
{
    public int Year => 2020;

    public int Day => 12;

    public string Title => "Rain Risk";

    public int Part1(ReadOnlySpan<char> span)
    {
        int n = 0, e = 0, r = 90;
        foreach (var item in span.EnumerateLines())
        {
            var num = int.Parse(item.Slice(1));
            switch (item[0])
            {
                case 'N': n += num; break;
                case 'S': n -= num; break;
                case 'E': e += num; break;
                case 'W': e -= num; break;
                case 'R': r = Math.Abs((r + num) % 360); break;
                case 'L':
                    r = (r - num) % 360;
                    if (r < 0)
                    {
                        r += 360;
                    }
                    break;
                case 'F':
                    switch (r)
                    {
                        case 0: n += num; break;
                        case 90: e += num; break;
                        case 180: n -= num; break;
                        case 270: e -= num; break;
                        default:
                            break;
                    }
                    break;
            }
        }
        return Math.Abs(e) + Math.Abs(n);
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        Point ship = new(),
            waypoint = new(10, 1);
        foreach (var item in span.EnumerateLines())
        {
            var num = int.Parse(item.Slice(1));
            switch (item[0])
            {
                case 'N': waypoint.Y += num; break;
                case 'S': waypoint.Y -= num; break;
                case 'E': waypoint.X += num; break;
                case 'W': waypoint.X -= num; break;
                case 'R': Rotate(ref waypoint, num); break;
                case 'L': Rotate(ref waypoint, 360 - num); break;
                case 'F':
                    ship.X += waypoint.X * num;
                    ship.Y += waypoint.Y * num;
                    break;
            }
        }
        return Math.Abs(ship.X) + Math.Abs(ship.Y);
    }

    static void Rotate(ref Point point, int num)
    {
        switch (num)
        {
            case 90: (point.X, point.Y) = (point.Y, -point.X); break;
            case 180: (point.X, point.Y) = (-point.X, -point.Y); break;
            case 270: (point.X, point.Y) = (-point.Y, point.X); break;
            default: break;
        }
    }
}
