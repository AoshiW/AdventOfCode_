namespace AdventOfCode.Y2020;

public class D07 : IDay<int>
{
    public int Year => 2020;

    public int Day => 7;

    public string Title => "Handy Haversacks";

    public int Part1(ReadOnlySpan<char> span)
    {
        var dic = ParseInput(span, false);
        var hs = new HashSet<string>();
        foreach (var item in dic)
        {
            if (Compute(item.Key, dic))
            {
                hs.Add(item.Key);
            }
        }
        return hs.Count;

        static bool Compute(string color, Dictionary<string, object> dic)
        {
            if (dic[color] is bool num)
            {
                return num;
            }
            var list = (dic[color] as List<string>)!;
            if (list.Any(x => x.Contains("shiny gold")))
            {
                dic[color] = true;
                return true;
            }
            bool sum = false;
            foreach (var item in list)
            {
                var subColor = item.Substring(item.IndexOf(' ') + 1);
                sum |= Compute(subColor[^1] != 's' ? subColor + "s" : subColor, dic);
            }
            dic[color] = sum;
            return sum;
        }
    }

    static Dictionary<string, object> ParseInput(ReadOnlySpan<char> span, object bagObj)
    {
        var dic = new Dictionary<string, object>();
        foreach (var item in span.EnumerateLines())
        {
            var i = item.IndexOf(" contain ");
            var line1 = item.Slice(i + 9);
            var key = item.Slice(0, i).ToString();
            if (line1.Contains("no other bags.", StringComparison.OrdinalIgnoreCase))
            {
                dic.Add(key, bagObj);
            }
            else
            {
                var bags = new List<string>();
                while ((i = line1.IndexOfAny(',', '.')) > -1)
                {
                    bags.Add(line1.Slice(0, i).Trim().ToString());
                    line1 = line1.Slice(i + 1);
                }
                dic.Add(key, bags);
            }
        };
        return dic;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var dic = ParseInput(span, 1);
        return Compute("shiny gold bags", dic) - 1;
        static int Compute(string color, Dictionary<string, object> dic)
        {
            if (dic[color] is int num)
            {
                return num;
            }
            var sum = 0;
            foreach (var item in (dic[color] as List<string>)!)
            {
                var subColor = item.Substring(item.IndexOf(' ') + 1);
                var count = int.Parse(item.AsSpan(0, item.IndexOf(' ')));
                sum += Compute(subColor[^1] != 's' ? subColor + "s" : subColor, dic) * count;
            }
            return sum + 1;
        }
    }
}
