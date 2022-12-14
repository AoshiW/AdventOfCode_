namespace AdventOfCode.Y2017;

public class D07 : IDay<string>
{
    public int Year => 2017;

    public int Day => 7;

    public string Title => "Recursive Circus";

    public string Part1(ReadOnlySpan<char> span)
    {
        var dic = new Dictionary<string, (int Value, List<string>? Vals)>();
        foreach (var line in span.EnumerateLines())
        {
            int state = 0, value = 0;
            string key = null!;
            List<string>? vals = null;
            foreach (var item in line.EnumerateSlices(" ()->,"))
            {
                if (state == 0)
                {
                    key = item.ToString();
                    state++;
                }
                else if (state == 1)
                {
                    value = int.Parse(item);
                    state++;
                }
                else
                {
                    vals ??= new();
                    vals.Add(item.ToString());
                }
            }
            dic[key] = (value, vals);
        }
        var allBre = dic.Where(x => x.Value.Vals is not null).SelectMany(x => x.Value.Vals).ToHashSet();
        return dic.First(x => x.Value.Vals is not null && !allBre.Contains(x.Key)).Key;
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
    }
}
