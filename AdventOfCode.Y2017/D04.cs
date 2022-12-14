namespace AdventOfCode.Y2017;

public class D04 : IDay<int>
{
    public int Year => 2017;

    public int Day => 4;

    public string Title => "High-Entropy Passphrases";

    public int Part1(ReadOnlySpan<char> span) => PassphrasesValid(span, x => x.ToString());

    public int Part2(ReadOnlySpan<char> span) => PassphrasesValid(span, x =>
    {
        Span<char> temp = stackalloc char[x.Length];
        x.CopyTo(temp);
        temp.Sort();
        return new(temp);
    });

    static int PassphrasesValid(ReadOnlySpan<char> span, ReadOnlySpanFunc<char,string> modifier)
    {
        int count = 0;
        var list = new List<string>();
        foreach (var line in span.EnumerateLines())
        {
            count++;
            foreach (var item in line.EnumerateSlices(" "))
            {
                list.Add(modifier(item));
            }
            foreach (var item in list)
            {
                if (list.Count(x => x == item) > 1)
                {
                    count--;
                    break;
                }
            }
            list.Clear();
        }
        return count;
    }
}
