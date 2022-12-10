namespace AdventOfCode.Y2021;

public class D04 : IDay<int>
{
    public int Year => 2021;

    public int Day => 4;

    public string Title => "Giant Squid!";

    public int Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        foreach (var item in input.Num)
        {
            foreach (var table in input.Tables)
            {
                if (For(table, item))
                {
                    return table.Sum(r => r.Sum(c => !c.IsCalled ? c.Value : 0)) * item;
                }
            }
        }
        return -1;
    }

    (List<int> Num, List<List<List<(bool IsCalled, int Value)>>> Tables) ParseInput(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines();
        enumerator.MoveNext();
        var num = new List<int>();
        foreach (var item in enumerator.Current.EnumerateSlices(","))
        {
            num.Add(int.Parse(item));
        }
        List<List<List<(bool, int)>>> tables = new();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.IsEmpty)
            {
                tables.Add(new());
                continue;
            }

            var tempnum = new List<(bool, int)>();
            foreach (var item in enumerator.Current.EnumerateSlices(" "))
            {
                tempnum.Add((false, int.Parse(item)));
            }
            tables[^1].Add(tempnum);
        }
        return (num, tables);
    }

    static bool For(List<List<(bool IsCalled, int Value)>> array, int num)
    {
        for (int r = 0; r < array.Count; r++)
        {
            for (int c = 0; c < array[0].Count; c++)
            {
                if (array[r][c].Value == num)
                {
                    array[r][c] = (true, num);
                    return
                        array[r].All(x => x.IsCalled) ||
                        array.Select(r => r[c]).All(x => x.IsCalled);
                }
            }
        }
        return false;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        foreach (var item in input.Num)
        {
            for (int i = 0; i < input.Tables.Count; i++)
            {
                if (For(input.Tables[i], item))
                {
                    if (input.Tables.Count == 1)
                    {
                        return input.Tables[0].Sum(r => r.Sum(c => !c.IsCalled ? c.Value : 0)) * item;
                    }
                    input.Tables.RemoveAt(i);
                    i--;
                }
            }
        }
        return -1;
    }
}
