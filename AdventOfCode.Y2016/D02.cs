using System.Text;

namespace AdventOfCode.Y2016;

public class D02 : IDay<string>
{
    public int Year => 2016;

    public int Day => 2;

    public string Title => "Bathroom Security";

    public string Part1(ReadOnlySpan<char> span)
    {
        int x = 1, y = 2;
        var sb = new StringBuilder();
        foreach (var line in span.EnumerateLines())
        {
            foreach (var item in line)
            {
                if (item == 'U' && x > 0)
                    x--;
                else if (item == 'D' && x < 2)
                    x++;
                else if (item == 'L' && y > 1)
                    y--;
                else if (item == 'R' && y < 3)
                    y++;
            }
            sb.Append(x * 3 + y);
        }
        return sb.ToString();
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var map = new char?[,]
        {
            { null, null, '1', null, null },
            { null, '2','3','4',null },
            { '5','6','7','8','9' },
            { null, 'A','B','C',null  },
            { null, null, 'D', null, null },
        };
        int x = 1, y = 2;
        var sb = new StringBuilder();
        foreach (var line in span.EnumerateLines())
        {
            foreach (var item in line)
            {
                if (item == 'U' && x > 0 && map[x - 1, y] is not null)
                    x--;
                else if (item == 'D' && x < 4 && map[x + 1, y] is not null)
                    x++;
                else if (item == 'L' && y > 0 && map[x, y - 1] is not null)
                    y--;
                else if (item == 'R' && y < 4 && map[x, y + 1] is not null)
                    y++;
            }
            sb.Append(map[x, y]);
        }
        return sb.ToString();
    }
}
