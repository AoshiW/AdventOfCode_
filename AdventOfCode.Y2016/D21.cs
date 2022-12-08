namespace AdventOfCode.Y2016;

public class D21 : IDay<string>
{
    public int Year => 2016;

    public int Day => 21;

    public string Title => "Scrambled Letters and Hash";

    const string tr = "abcdefgh";
    const string tr2 = "fbgdceah";

    public string Part1(ReadOnlySpan<char> span)
    {
        Span<char> text = stackalloc char[tr.Length];
        Span<char> textCache = stackalloc char[tr.Length];
        tr.CopyTo(text);
        foreach (var item in span.EnumerateLines())
        {
            var enumerator = item.EnumerateSlices(" ");
            enumerator.MoveNext();
            if (enumerator.Current.Equals("swap", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                if (enumerator.Current[0] == 'p')
                {
                    enumerator.MoveNext();
                    var p1 = int.Parse(enumerator.Current);
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    var p2 = int.Parse(enumerator.Current);
                    var temp = text[p1];
                    text[p1] = text[p2];
                    text[p2] = temp;
                }
                else
                {
                    enumerator.MoveNext();
                    var c1 = enumerator.Current[0];
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    var c2 = enumerator.Current[0];
                    foreach (ref var c in text)
                    {
                        if (c == c1)
                            c = c2;
                        else if (c == c2)
                            c = c1;
                    }
                }
            }
            else if (enumerator.Current.Equals("move", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                enumerator.MoveNext();
                var from = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                var to = int.Parse(enumerator.Current);
                var temp = text[from];
                if (from < to)
                {
                    while (from != to)
                    {
                        text[from] = text[from + 1];
                        from++;
                    }
                }
                else
                {
                    while (from != to)
                    {
                        text[from] = text[from - 1];
                        from--;
                    }
                }
                text[from] = temp;
            }
            else if (enumerator.Current.Equals("rotate", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                int num;
                if (enumerator.Current[0] == 'l')
                {
                    enumerator.MoveNext();
                    var l = int.Parse(enumerator.Current);
                    num = tr.Length - l;
                }
                else if (enumerator.Current[0] == 'r')
                {
                    enumerator.MoveNext();
                    num = int.Parse(enumerator.Current);
                }
                else
                {
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    num = 1 + text.IndexOf(enumerator.Current[0]);
                    if (num > 4)
                        num++;
                    num %= text.Length;
                }
                text.Slice(text.Length - num).CopyTo(textCache);
                for (int i = text.Length - 1; i >= num; i--)
                {
                    text[i] = text[i - num];
                }
                textCache.Slice(0, num).CopyTo(text);
            }
            else
            {
                enumerator.MoveNext();
                enumerator.MoveNext();
                var from = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                var to = int.Parse(enumerator.Current);
                text.Slice(from, to - from + 1).Reverse();
            }
        }
        return text.ToString();
    }
    public void Part1(ReadOnlySpan<char> span, ReadOnlySpan<char> input, Span<char> output)
    {
        Span<char> textCache = stackalloc char[input.Length];
        input.CopyTo(output);
        foreach (var item in span.EnumerateLines())
        {
            var enumerator = item.EnumerateSlices(" ");
            enumerator.MoveNext();
            if (enumerator.Current.Equals("swap", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                if (enumerator.Current[0] == 'p')
                {
                    enumerator.MoveNext();
                    var p1 = int.Parse(enumerator.Current);
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    var p2 = int.Parse(enumerator.Current);
                    (output[p2], output[p1]) = (output[p1], output[p2]);
                }
                else
                {
                    enumerator.MoveNext();
                    var c1 = enumerator.Current[0];
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    var c2 = enumerator.Current[0];
                    foreach (ref var c in output)
                    {
                        if (c == c1)
                            c = c2;
                        else if (c == c2)
                            c = c1;
                    }
                }
            }
            else if (enumerator.Current.Equals("move", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                enumerator.MoveNext();
                var from = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                var to = int.Parse(enumerator.Current);
                var temp = output[from];
                if (from < to)
                {
                    while (from != to)
                    {
                        output[from] = output[from + 1];
                        from++;
                    }
                }
                else
                {
                    while (from != to)
                    {
                        output[from] = output[from - 1];
                        from--;
                    }
                }
                output[from] = temp;
            }
            else if (enumerator.Current.Equals("rotate", StringComparison.OrdinalIgnoreCase))
            {
                enumerator.MoveNext();
                int num;
                if (enumerator.Current[0] == 'l')
                {
                    enumerator.MoveNext();
                    var l = int.Parse(enumerator.Current);
                    num = tr.Length - l;
                }
                else if (enumerator.Current[0] == 'r')
                {
                    enumerator.MoveNext();
                    num = int.Parse(enumerator.Current);
                }
                else
                {
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    enumerator.MoveNext();
                    num = 1 + output.IndexOf(enumerator.Current[0]);
                    if (num > 4)
                        num++;
                    num %= output.Length;
                }
                output.Slice(output.Length - num).CopyTo(textCache);
                for (int i = output.Length - 1; i >= num; i--)
                {
                    output[i] = output[i - num];
                }
                textCache.Slice(0, num).CopyTo(output);
            }
            else
            {
                enumerator.MoveNext();
                enumerator.MoveNext();
                var from = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                var to = int.Parse(enumerator.Current);
                output.Slice(from, to - from + 1).Reverse();
            }
        }
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
    }
}
