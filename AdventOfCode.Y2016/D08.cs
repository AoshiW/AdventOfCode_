using System.Text;

namespace AdventOfCode.Y2016;

public class D08 : IDay<string>
{
    public int Year => 2016;

    public int Day => 8;

    public string Title => "Two-Factor Authentication";

    public string Part1(ReadOnlySpan<char> span)
    {
        return Process(span).Count(x => x).ToString();
    }

    static bool[,] Process(ReadOnlySpan<char> span)
    {
        var c = new bool[6, 50];
        var temp = new bool[50];
        foreach (var item in span.EnumerateLines())
        {
            var enumerator = item.EnumerateSlices(" ");
            enumerator.MoveNext();
            if (enumerator.Current.Equals("rect", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                int tt = enumerator.Current.IndexOf('x');
                var x = int.Parse(enumerator.Current.Slice(0, tt));
                tt = int.Parse(enumerator.Current.Slice(tt + 1));
                for (int ix = 0; ix < x; ix++)
                {
                    for (int i = 0; i < tt; i++)
                    {
                        c[i, ix] = true;
                    }
                }
            }
            else
            {
                enumerator.MoveNext();
                var type = enumerator.Current;
                enumerator.MoveNext();
                var q = int.Parse(enumerator.Current.Slice(enumerator.Current.IndexOf('=') + 1));
                enumerator.MoveNext();
                enumerator.MoveNext();
                var qq = int.Parse(enumerator.Current);
                if (type.Equals("row", StringComparison.OrdinalIgnoreCase))
                {
                    for (int i = 0; i < qq; i++)
                    {
                        temp[i] = c[q, i + (50 - qq)];
                    }
                    for (int i = 49; i >= qq; i--)
                    {
                        c[q, i] = c[q, i - qq];
                    }
                    for (int i = 0; i < qq; i++)
                    {
                        c[q, i] = temp[i]; ;
                    }
                }
                else
                {
                    for (int i = 0; i < qq; i++)
                    {
                        temp[i] = c[i + (6 - qq), q];
                    }
                    for (int i = 5; i >= qq; i--)
                    {
                        c[i, q] = c[i - qq, q];
                    }
                    for (int i = 0; i < qq; i++)
                    {
                        c[i, q] = temp[i]; ;
                    }
                }
            }
        }
        return c;
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var result = Process(span);
        var sb = new StringBuilder();
        for (int i = 0; i < result.GetLength(1); i += 5)
        {
            var bites = result.GetSection(0, 6, i, i + 5).SelectMany(x => x);
            var hash = bites.Aggregate(0, (n, b) => n = (n << 1) + (b ? 1 : 0));
            sb.Append(hash.Ocr());
        }
        return sb.ToString();
    }
}
