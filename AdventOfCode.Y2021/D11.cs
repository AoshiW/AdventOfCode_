using System.Drawing;

namespace AdventOfCode.Y2021;

public partial class D11 : IDay<int>
{
    public int Year => 2021;

    public int Day => 11;

    public string Title => "Dumbo Octopus";

    public int Part1(ReadOnlySpan<char> span)
    {
        var map = new List<MapItem[]>();
        var flashes = 0;
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToString().Select(x => new MapItem(x)).ToArray());
        }
        var pointOffset8 = MagicNumbers.Offset8;
        var queue = new Queue<Point>();
        for (int i = 0; i < 100; i++)
        {
            foreach (var item in map.SelectMany(x => x))
            {
                item.CharNum++;
            }
            bool change = true;
            while (change)
            {
                change = false;
                foreach (var item in GetPointEnumerator(map))
                {
                    if (map[item.X][item.Y].CharNum > '9' && !map[item.X][item.Y].Flashed)
                    {
                        change = true; ;
                        map[item.X][item.Y].Flashed = true;
                        foreach (var off in pointOffset8)
                        {
                            var newPoint = item + off;
                            if (newPoint.X >= 0 && newPoint.Y >= 0 && newPoint.X < map.Count && newPoint.Y < map[0].Length)
                                map[newPoint.X][newPoint.Y].CharNum++;
                        }
                    }
                }
            }
            foreach (var item in map.SelectMany(x => x))
            {
                if (item.Flashed)
                {
                    item.Flashed = false;
                    item.CharNum = '0';
                    flashes++;
                }
            }
        }
        return flashes;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var map = new List<MapItem[]>();
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToString().Select(x => new MapItem(x)).ToArray());
        }
        int i = 0;
        var pointOffset8 = MagicNumbers.Offset8;
        for (; map.SelectMany(x => x).Any(x => x.CharNum != '0'); i++)
        {
            foreach (var item in map.SelectMany(x => x))
            {
                item.CharNum++;
            }
            bool change = true;
            while (change)
            {
                change = false;
                foreach (var item in GetPointEnumerator(map))
                {
                    if (!map[item.X][item.Y].Flashed && map[item.X][item.Y].CharNum > '9')
                    {
                        change = true; ;
                        map[item.X][item.Y].Flashed = true;
                        foreach (var off in pointOffset8)
                        {
                            var newPoint = item + off;
                            if (newPoint.X >= 0 && newPoint.Y >= 0 && newPoint.X < map.Count && newPoint.Y < map[0].Length)
                                map[newPoint.X][newPoint.Y].CharNum++;
                        }
                    }
                }
            }
            foreach (var item in map.SelectMany(x => x))
            {
                if (item.Flashed)
                {
                    item.Flashed = false;
                    item.CharNum = '0';
                }
            }
        }
        return i;
    }
    static IEnumerable<Point> GetPointEnumerator<T>(List<T[]> map)
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
