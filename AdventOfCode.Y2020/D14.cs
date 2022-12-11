using System.Text;

namespace AdventOfCode.Y2020;

public class D14 : IDay<ulong>
{
    public int Year => 2020;

    public int Day => 14;

    public string Title => "Docking Data";

    public ulong Part1(ReadOnlySpan<char> span)
    {
        var mem = new Dictionary<int, ulong>();
        ReadOnlySpan<char> mask = default;
        foreach (var item in span.EnumerateLines())
        {
            var slice = item.Slice(item.LastIndexOf(' ') + 1);
            if (item[1] == 'a')
            {
                mask = slice;
            }
            else
            {
                var sb = new StringBuilder(Convert.ToString(long.Parse(slice), 2));
                sb.Insert(0, "0", 36 - sb.Length);
                for (int i = 0; i < sb.Length; i++)
                {
                    if (mask[i] != 'X')
                    {
                        sb[i] = mask[i];
                    }
                }
                mem[int.Parse(item.Slice(4, item.IndexOf(']') - 4))] = Convert.ToUInt64(sb.ToString(), 2);
            }
        }
        var sum = 0uL;
        foreach (var item in mem)
        {
            sum += item.Value;
        }
        return sum;
    }

    public ulong Part2(ReadOnlySpan<char> span)
    {
        var mem = new Dictionary<string, ulong>();
        ReadOnlySpan<char> mask = default;
        foreach (var item in span.EnumerateLines())
        {
            var str = item.Slice(item.LastIndexOf(' ') + 1);
            if (item[1] == 'a')
            {
                mask = str;
            }
            else
            {
                var sb = new StringBuilder(Convert.ToString(long.Parse(item.Slice(4, item.IndexOf(']') - 4)), 2));
                sb.Insert(0, "0", 36 - sb.Length);
                for (int i = 0; i < sb.Length; i++)
                {
                    if (mask[i] != '0')
                    {
                        sb[i] = mask[i];
                    }
                }
                int countOfX = sb.ToString().Count(x => x == 'X');
                char[] ca = new char[sb.Length];
                var value = ulong.Parse(str);
                for (int i = 0; i < Math.Pow(2, countOfX); i++)
                {
                    var bin = Convert.ToString(i, 2).PadLeft(countOfX, '0');
                    sb.CopyTo(0, ca, ca.Length);
                    for (int c = 0; c < countOfX; c++)
                    {
                        ca[Array.IndexOf(ca, 'X')] = bin[c];
                    }
                    mem[new string(ca)] = value;
                }
            }
        }
        var sum = 0UL;
        foreach (var item in mem)
        {
            sum += item.Value;
        }
        return sum;
    }
}
