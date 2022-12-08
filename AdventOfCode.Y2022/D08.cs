namespace AdventOfCode.Y2022;

public class D08 : IDay<int>
{
    public int Year => 2022;

    public string Title => "Treetop Tree House";

    public int Day => 8;

    public int Part1(ReadOnlySpan<char> span)
    {
        var map = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToString());
        }
        int count = 0;
        for (int x = 1; x < map.Count - 1; x++)
        {
            for (int y = 1; y < map[0].Length - 1; y++)
            {
                if (IsVisibleFromOutside(x, y, map))
                    count++;
            }
        }
        return count + (map.Count + map[0].Length) * 2 - 4;
    }

    static bool IsVisibleFromOutside(int x, int y, List<string> map)
    {
        var c = map[x][y];
        var line = map[x];
        var isVisible = true;
        for (int i = y + 1; i < line.Length; i++)
        {
            if (line[i] >= c)
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
            return true;
        isVisible = true;
        for (int i = 0; i < y; i++)
        {
            if (line[i] >= c)
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
            return true;
        isVisible = true;
        for (int i = x + 1; i < map.Count; i++)
        {
            if (map[i][y] >= c)
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
            return true;
        isVisible = true;
        for (int i = 0; i < x; i++)
        {
            if (map[i][y] >= c)
            {
                isVisible = false;
                break;
            }
        }
        return isVisible;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var map = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            map.Add(item.ToString());
        }
        int score = 0;
        for (int x = 1; x < map.Count - 1; x++)
        {
            for (int y = 1; y < map[0].Length - 1; y++)
            {
                score = Math.Max(score, ScenicScore(x, y, map));
            }
        }
        return score;
    }

    static int ScenicScore(int x, int y, List<string> map)
    {
        Span<int> score = stackalloc int[4];
        var c = map[x][y];
        var line = map[x];
        for (int i = y + 1; i < line.Length; i++)
        {
            score[0]++;
            if (line[i] >= c)
                break;
        }
        for (int i = y - 1; i >= 0; i--)
        {
            score[1]++;
            if (line[i] >= c)
                break;
        }
        for (int i = x + 1; i < map.Count; i++)
        {
            score[2]++;
            if (map[i][y] >= c)
                break;
        }
        for (int i = x - 1; i >= 0; i--)
        {
            score[3]++;
            if (map[i][y] >= c)
                break;
        }
        return score[3] * score[2] * score[1] * score[0];
    }
}
