namespace AdventOfCode.Y2021;

public class D05 : IDay<int>
{
    public int Year => 2021;

    public int Day => 5;

    public string Title => "Hydrothermal Venture";

    public int Part1(ReadOnlySpan<char> span) => Fnc(span, false);

    public int Part2(ReadOnlySpan<char> span) => Fnc(span, true);

    static int Fnc(ReadOnlySpan<char> span, bool diagonal)
    {
        var m = new int[1000, 1000];
        Span<int> arr = stackalloc int[4];
        foreach (var item in span.EnumerateLines())
        {
            var enumerator = item.EnumerateSlices(",-> ");
            for (int i = 0; enumerator.MoveNext(); i++)
            {
                arr[i] = int.Parse(enumerator.Current);
            }
            if (arr[0] == arr[2] || arr[1] == arr[3])
            {
                int r1 = Math.Min(arr[0], arr[2]);
                var r2 = Math.Max(arr[0], arr[2]);
                int c0 = Math.Min(arr[1], arr[3]);
                int c2 = Math.Max(arr[1], arr[3]);
                for (; r1 <= r2; r1++)
                {
                    for (int c1 = c0; c1 <= c2; c1++)
                    {
                        m[r1, c1]++;
                    }
                }
            }
            else if (diagonal)
            {
                int r = arr[0];
                int c = arr[1];
                while (r != arr[2] && c != arr[3])
                {
                    m[r, c]++;
                    if (arr[0] < arr[2])
                    {
                        r++;
                    }
                    else
                    {
                        r--;
                    }
                    if (arr[1] < arr[3])
                    {
                        c++;
                    }
                    else
                    {
                        c--;
                    }
                }
                m[r, c]++;
            }
        }
        return m.Count(x => x > 1);
    }
}
