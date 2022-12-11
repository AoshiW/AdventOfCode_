namespace AdventOfCode.Y2020;

public class D03 : IDay<long>
{
    public int Year => 2020;

    public int Day => 3;

    public string Title => "Toboggan Trajectory";

    public long Part1(ReadOnlySpan<char> span)
    {
        int x = 0, tree = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (item[x] == '#')
                tree++;
            x = (x + 3) % item.Length;
        }
        return tree;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        int x, tmp;
        long tree = 1;
        ReadOnlySpan<(int,int)> qq = stackalloc[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
        for (int q = 0; q < qq.Length; q++)
        {
            tmp = x = 0;
            var enumerator = span.EnumerateLines();
            while (enumerator.MoveNext())
            {
                for (int i = 1; i < qq[q].Item2; i++)
                {
                    enumerator.MoveNext();
                }
                var item = enumerator.Current;
                if (item[x] == '#')
                    tmp++;
                x = (x + qq[q].Item1) % item.Length;
            }
            tree *= tmp;
        }
        return tree;
    }
}
