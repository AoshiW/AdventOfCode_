namespace AdventOfCode.Y2022;

public class D10 : IDay<string>
{
    public int Year => 2022;
    public string Title => "Cathode-Ray Tube";
    public int Day => 10;

    public string Part1(ReadOnlySpan<char> span)
    {
        var regX = 1;
        var cycle = 0;
        var sum = 0;
        ReadOnlySpan<int> s = stackalloc int[] { 20, 60, 100, 140, 180, 220 };
        foreach (var item in span.EnumerateLines())
        {
            if (item.Slice(0, 4) is "addx")
            {
                cycle += 2;
                if (s.Contains(cycle))
                {
                    sum += (cycle) * regX;
                }
                if (s.Contains(cycle - 1))
                {
                    sum += (cycle - 1) * regX;
                }
                var num = int.Parse(item.Slice(item.IndexOf(' ') + 1));
                regX += num;
            }
            else
            {
                cycle++;
                if (s.Contains(cycle))
                {
                    sum += cycle * regX;
                }
            }

        }
        return sum.ToString();
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        Span<bool> map = stackalloc bool[240];
        var regX = 1;
        var cycle = 0;
        ReadOnlySpan<int> s = stackalloc int[] { 20, 60, 100, 140, 180, 220 };
        foreach (var item in span.EnumerateLines())
        {
            if (item.Slice(0, 4) is "addx")
            {
                map[cycle] = Draw(regX - 1, cycle);
                map[cycle + 1] = Draw(regX - 1, cycle + 1);
                cycle += 2;
                regX += int.Parse(item.Slice(item.IndexOf(' ') + 1));
            }
            else
            {
                map[cycle] = Draw(regX - 1, cycle);
                cycle++;
            }
        }
        Span<int> codei = stackalloc int[8];
        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 40; c++)
            {
                var p = codei[c / 5] << 1;
                codei[c / 5] = p | (map[r * 40 + c] ? 1 : 0);
            }
        }
        Span<char> code = stackalloc char[8];
        for (int i = 0; i < code.Length; i++)
        {
            code[i] = codei[i].Ocr();
        }
        return code.ToString();
    }

    static bool Draw(int reg, int cycle)
    {
        cycle %= 40;
        return reg == cycle || reg + 1 == cycle || reg + 2 == cycle;
    }
}
