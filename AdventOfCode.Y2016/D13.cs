using System.Drawing;
using System.Runtime.InteropServices;

namespace AdventOfCode.Y2016;

public class D13 : IDay<int>
{
    public int Year => 2016;

    public int Day => 13;

    public string Title => "A Maze of Twisty Little Cubicles";

    static bool IsNotWall(Point p, int favoriteNumber)
    {
        var num = (uint)(p.X * p.X + 3 * p.X + 2 * p.X * p.Y + p.Y + p.Y * p.Y + favoriteNumber);
        ushort c = 0;
        for (int i = 0; i < 16; i++)
        {
            if ((num & 1 << i) != 0)
                c++;
        }
        return (c & 1) == 0;
    }

    public int Part1(ReadOnlySpan<char> span)
    {
        var favoriteNumber = int.Parse(span);
        var maze = new Dictionary<Point, bool>();
        var nextPoints = new Stack<(int, Point Point)>();
        nextPoints.Push((0, new(1, 1)));
        var e = new Point(31, 39);
        while (true)
        {
            var z = nextPoints.Pop();
            if (z.Point == e)
                return z.Item1;
            foreach (var item in Moves)
            {
                var newPoint = z.Point + item;
                ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(maze, newPoint, out var exist);
                if (newPoint.X < 0 || newPoint.Y < 0 || exist)
                    continue;
                var isNotWall = IsNotWall(newPoint, favoriteNumber);
                value = isNotWall;
                if (isNotWall)
                {
                    nextPoints.Push((z.Item1 + 1, newPoint));
                }
            }
        }
    }

    static readonly Size[] Moves = new Size[] { new(0, 1), new(-1, 0), new(1, 0), new(0, -1) };

    public int Part2(ReadOnlySpan<char> span)
    {
        var favoriteNumber = int.Parse(span);
        var maze = new Dictionary<Point, bool>();
        var nextPoints = new Stack<(int, Point Point)>();
        nextPoints.Push((0, new(1, 1)));
        int i = 1;
        while (nextPoints.TryPop(out var pointInfo))
        {
            foreach (var item in Moves)
            {
                var newPoint = pointInfo.Point + item;
                ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(maze, newPoint, out var exist);
                if (newPoint.X < 0 || newPoint.Y < 0 || exist)
                    continue;
                var isNotWall = IsNotWall(newPoint, favoriteNumber);
                value = isNotWall;
                if (isNotWall && pointInfo.Item1 + 1 < 50)
                {
                    i++;
                    nextPoints.Push((pointInfo.Item1 + 1, newPoint));
                }
            }
        }
        return i;
    }
}
