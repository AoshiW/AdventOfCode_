namespace AdventOfCode.Y2020;

public class D19 : IDay<int>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 19;

    /// <inheritdoc/>
    public string Title => "Monster Messages";

    /// <inheritdoc/>
    public int Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        var all = CreateAll(input.Rules);
        return input.Messages.Count(input => all.Contains(input));
    }

    static List<string> CreateAll(Dictionary<int, List<string>> rules, int from = 0)
    {
        var all = new List<string>();
        foreach (var item in rules[from])
        {
            var li = new List<string>();
            foreach (var item2 in item.AsSpan().EnumerateSlices("\" "))
            {
                if (int.TryParse(item2, out var value))
                {
                    var r = CreateAll(rules, value); ;
                    li = li.Count == 0 ? r : li.SelectMany(x => r.Select(v => x + v)).ToList();
                }
                else
                {
                    if (li.Count == 0)
                    {
                        li.Add(item2.ToString());
                    }
                    else
                    {
                        for (int i = 0; i < li.Count; i++)
                        {
                            li[i] += item2[0];
                        }
                    }
                }
            }
            all.AddRange(li);
        }
        return all;
    }

    static (Dictionary<int, List<string>> Rules, List<string> Messages) ParseInput(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines();
        var dic = new Dictionary<int, List<string>>();
        while (enumerator.MoveNext() && enumerator.Current.Length != 0)
        {
            var rules = new List<string>();
            var item = enumerator.Current;
            int i = item.IndexOf(':');
            var ruleNumber = int.Parse(item.Slice(0, i));
            item = item.Slice(i + 2);
            foreach (var numm in item.EnumerateSlices("|"))
            {
                rules.Add(numm.Trim().ToString());
            }
            dic.Add(ruleNumber, rules);
        }
        var list = new List<string>();
        while (enumerator.MoveNext())
        {
            list.Add(enumerator.Current.ToString());
        }
        return (dic, list);
    }

    /// <inheritdoc/>
    public int Part2(ReadOnlySpan<char> span) => throw new NotImplementedException();
}
