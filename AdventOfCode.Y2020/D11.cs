using System.Drawing;

namespace AdventOfCode.Y2020;

public class D11 : IDay<int>
{
    public int Year => 2020;

    public int Day => 11;

    public string Title => "Seating System";

    public int Part1(ReadOnlySpan<char> span)
    {
        var map = ParseInput(span);
        for (int i = 0; i == 0 || IsSame(map); i++)
        {
            foreach (var item in GetPointEnumerator(map[0]))
            {
                switch (map[i % 2][item.Y][item.X])
                {
                    case '#':
                        map[(i + 1) % 2][item.Y][item.X] = um(item.Y, item.X, map[i % 2]) >= 4 ? 'L' : '#';
                        break;
                    case 'L':
                        map[(i + 1) % 2][item.Y][item.X] = um(item.Y, item.X, map[i % 2]) == 0 ? '#' : 'L';
                        break;
                    default:
                        break;
                }
            }
        }
        return map[0].Sum(x => x.Count(c => c == '#'));

        static int um(int x, int y, List<char[]> map)
        {
            int max = 0;
            for (int ix = x == 0 ? 0 : -1; ix < (x == map.Count - 1 ? 1 : 2); ix++)
            {
                for (int iy = y == 0 ? 0 : -1; iy < (y == map[0].Length - 1 ? 1 : 2); iy++)
                {
                    if (!(ix == 0 && iy == 0))
                        max += map[x + ix][y + iy] == '#' ? 1 : 0;
                }
            }
            return max;
        }
    }

    static List<char[]>[] ParseInput(ReadOnlySpan<char> span)
    {
        var map = new List<char[]>[]
            {
                new(),new()
            };
        foreach (var item in span.EnumerateLines())
        {
            map[0].Add(item.ToArray());
            map[1].Add(item.ToArray());
        }
        return map;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var map = ParseInput(span);
        for (int i = 0; i == 0 || IsSame(map); i++)
        {
            foreach (var item in GetPointEnumerator(map[0]))
            {
                switch (map[i % 2][item.Y][item.X])
                {
                    case '#':
                        map[(i + 1) % 2][item.Y][item.X] = um(item, map[i % 2]) >= 5 ? 'L' : '#';
                        break;
                    case 'L':
                        map[(i + 1) % 2][item.Y][item.X] = um(item, map[i % 2]) == 0 ? '#' : 'L';
                        break;
                    default:
                        break;
                }
            }
        }
        return map[0].Sum(x => x.Count(c => c == '#'));

        static int um(Point p, List<char[]> map)
        {
            var surroundingPoints = MagicNumbers.Offset8;
            int max = 0;
            foreach (var item in surroundingPoints)
            {
                bool next = true;
                for (int i = 1; next; i++)
                {
                    Point np = p;
                    np.X += item.Width * i;
                    np.Y += item.Height * i;
                    if (np.X >= 0 && np.Y >= 0 && np.X < map[0].Length && np.Y < map.Count)
                    {
                        if (map[np.Y][np.X] == '.')
                        {
                            continue;
                        }
                        if (map[np.Y][np.X] == '#')
                        {
                            max++;
                        }
                    }
                    next = false;
                }
            }
            return max;
        }
    }

    static bool IsSame(List<char[]>[] map)
    {
        for (int r = 0; r < map[0].Count; r++)
        {
            for (int c = 0; c < map[0][0].Length; c++)
            {
                if (map[0][r][c] != map[1][r][c])
                {
                    return true;
                }
            }
        }
        return false;
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
