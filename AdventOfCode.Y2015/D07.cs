using System.Runtime.InteropServices;

namespace AdventOfCode.Y2015;

public class D07 : IDay<int>
{
    public int Year => 2015;

    public int Day => 7;

    public string Title => "Some Assembly Required";

    public int Part1(ReadOnlySpan<char> span)
    {
        var dic = ParseInput(span);
        return Get("a", dic);
    }

    static Dictionary<string, object> ParseInput(ReadOnlySpan<char> span)
    {
        var dic = new Dictionary<string, object>();
        foreach (var item in span.EnumerateLines())
        {
            var index = item.LastIndexOf(' ');
            var temp = item.Slice(0, index - 3);
            dic.Add(
                item.Slice(index + 1).ToString(),
                int.TryParse(temp, out var value) ? value : temp.ToString()
                );
        }
        return dic;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var dic = ParseInput(span);
        dic["b"] = Part1(span);
        return Get("a", dic);
    }

    static int Get(string key, Dictionary<string, object> dic)
    {
        ref var value = ref CollectionsMarshal.GetValueRefOrNullRef(dic, key);
        if (value is int num)
        {
            return num;
        }
        var valueStr = value as string;
        var split = valueStr!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 1)
        {
            var res = Get(split[0], dic);
            value = res;
            return res;
        }
        else if (split.Length == 2)
        {
            var res = ~Get(split[1], dic);
            value = res;
            return res;
        }
        else
        {
            if (!int.TryParse(split[0], out var x))
            {
                x = Get(split[0], dic);
            }
            if (!int.TryParse(split[2], out var y))
            {
                y = Get(split[2], dic);
            }

            var res = split[1] switch
            {
                "AND" => x & y,
                "OR" => x | y,
                "LSHIFT" => x << y,
                "RSHIFT" => x >> y,
                _ => throw new Exception(),
            };
            value = res;
            return res;
        }
    }
}
