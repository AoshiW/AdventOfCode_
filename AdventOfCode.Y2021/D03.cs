namespace AdventOfCode.Y2021;

public class D03 : IDay<int>
{
    public int Year => 2021;

    public int Day => 3;

    public string Title => "Binary Diagnostic!";

    public int Part1(ReadOnlySpan<char> span)
    {
        var l = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            l.Add(item.ToString());
        }
        int gr = 0, er = 0;
        for (int i = 0; i < l[0].Length; i++)
        {
            var c = l.Count(x => x[i] == '1');
            if (c < l.Count - c)
            {
                gr <<= 1;
                er = er << 1 | 1;
            }
            else
            {
                gr = gr << 1 | 1;
                er <<= 1;
            }
        }
        return er * gr;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        List<string> l = new(), og = new(), co2 = new();
        foreach (var item in span.EnumerateLines())
        {
            l.Add(item.ToString());
        }
        int c = l.Count(x => x[0] == '1');
        var ch = c > l.Count - c ? '1' : '0';
        for (int i = 0; i < l.Count; i++)
        {
            if (l[i][0] == ch)
                og.Add(l[i]);
            else
                co2.Add(l[i]);
        }
        Rating(og, '1');
        Rating(co2, '0');
        return Convert.ToInt32(og[0], 2) * Convert.ToInt32(co2[0], 2);
    }

    static void Rating(List<string> l, char lastBit)
    {
        for (int i = 1; i < l[0].Length - 1 && l.Count > 1; i++)
        {
            var count = l.Count(x => x[i] == lastBit);
            var ch = count > l.Count - count ? '1' : '0';
            l.RemoveAll(x => x[i] != ch);
        }
        l.RemoveAll(x => x[^1] != lastBit);
    }
}
