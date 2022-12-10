using System.Drawing;
using System.Text;

namespace AdventOfCode.Y2021;

public class D13 : IDay<string>
{
    public int Year => 2021;

    public int Day => 13;

    public string Title => "Transparent Origami";

    public string Part1(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines();
        HashSet<Point> hs = new(), temp = new();
        while (enumerator.MoveNext() && !enumerator.Current.IsEmpty)
        {
            var item = enumerator.Current;
            var i = item.IndexOf(',');
            hs.Add(new(int.Parse(item.Slice(0, i)), int.Parse(item.Slice(i + 1))));
        }
        enumerator.MoveNext();
        FoldAlong(ref hs, ref temp, ref enumerator);
        return hs.Count.ToString();
    }

    static void FoldAlong(ref HashSet<Point> map, ref HashSet<Point> temp, ref SpanLineEnumerator enumerator)
    {
        var enumerator2 = enumerator.Current.EnumerateSlices("= ", 3);
        var c = enumerator2.Current[0];
        enumerator2.MoveNext();
        var num = int.Parse(enumerator2.Current);
        foreach (var p in map)
        {
            if (c == 'y')
            {
                if (p.Y > num)
                {
                    temp.Add(new(p.X, new Index(p.Y - num, true).GetOffset(num)));
                }
                else if (p.Y != num)
                    temp.Add(p);
            }
            else
            {
                if (p.X > num)
                {
                    temp.Add(new(new Index(p.X - num, true).GetOffset(num), p.Y));
                }
                else if (p.X != num)
                    temp.Add(p);
            }
        }
        (map, temp) = (temp, map);
        temp.Clear();
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines();
        HashSet<Point> hs = new(), temp = new();
        while (enumerator.MoveNext() && !enumerator.Current.IsEmpty)
        {
            var item = enumerator.Current;
            var i = item.IndexOf(',');
            hs.Add(new(int.Parse(item.Slice(0, i)), int.Parse(item.Slice(i + 1))));
        }
        while (enumerator.MoveNext())
        {
            FoldAlong(ref hs, ref temp, ref enumerator);
        }
        Span<char> code = stackalloc char[8];
        var map = new bool[6, 40];
        foreach (var item in hs)
        {
            map[item.Y, item.X] = true;
        }
        for (int i = 0; i < 40; i += 5)
        {
            var bites = map.GetSection(0, 6, i, i + 5).SelectMany(x => x);
            var hash = bites.Aggregate(0, (n, b) => n = (n << 1) + (b ? 1 : 0));
            code[i / 5] = hash.Ocr();
        }
        return new(code);
    }
}
