namespace AdventOfCode.Y2022;

//todo .NET 8     CollectionExtensions.AddRange<T>(this List<T> list, ReadOnlySpan<T> source)
public class D05 : IDay<string>
{
    public int Year => 2022;

    public int Day => 5;

    public string Title => "Supply Stacks";

    public string Part1(ReadOnlySpan<char> span) => RearrangingCrates(span, CrateMover9000);
    
    public string Part2(ReadOnlySpan<char> span) => RearrangingCrates(span, CrateMover9001);

    static void CrateMover9000(List<char> from, List<char> to, int count)
    {
        var fromIndex = from.Count - count;
        for (int i = from.Count - 1; i >= fromIndex; i--)
        {
            to.Add(from[i]);
        }
        from.RemoveRange(fromIndex, count);
    }

    static void CrateMover9001(List<char> from, List<char> to, int count)
    {
        var fromIndex = from.Count - count;
        for (int i = 0; i < count; i++)
        {
            to.Add(from[fromIndex + i]);
        }
        from.RemoveRange(fromIndex, count);
    }

    static string RearrangingCrates(ReadOnlySpan<char> span, Action<List<char>, List<char>, int> crateMover)
    {
        var list = new List<List<char>>();
        var enumerator = span.EnumerateLines();
        while (enumerator.MoveNext() && !enumerator.Current.IsEmpty)
        {
            var item = enumerator.Current;
            var index = item.IndexOf('[');
            if (index == -1)
                continue;
            for (int i = index + 1; i < item.Length; i += 4)
            {
                if (item[i] != ' ')
                {
                    index = (i - 1) / 4;
                    while (list.Count <= index)
                        list.Add(new());
                    list[index].Add(item[i]);
                }
            }
        }
        foreach (var item in list)
        {
            item.Reverse();
        }
        foreach (var item in enumerator)
        {
            var s = item.Slice(5);
            var index = s.IndexOf(' ');
            var count = int.Parse(s.Slice(0, index));
            s = s.Slice(index + 6);
            index = s.IndexOf(' ');
            var from = int.Parse(s.Slice(0, index)) - 1;
            index = s.LastIndexOf(' ');
            var to = int.Parse(s.Slice(index + 1)) - 1;

            var toList = list[to];
            var fromList = list[from];
            crateMover(fromList, toList, count);
        }
        return string.Create(list.Count, list, (s, a) =>
        {
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = a[i][^1];
            }
        });
    }
}
