namespace AdventOfCode.Y2016;

public class D07 : IDay<int>
{
    public int Year => 2016;

    public int Day => 7;

    public string Title => "Internet Protocol Version 7";

    public int Part1(ReadOnlySpan<char> span)
    {
        int c = 0;
        foreach (var line in span.EnumerateLines())
        {
            var inBrackets = line[0] == '[';
            bool ib = false, ob = false;
            foreach (var item in line.EnumerateSlices("[]"))
            {
                if (inBrackets)
                    ib |= SupportTls(item);
                else
                    ob |= SupportTls(item);
                inBrackets = !inBrackets;
            }
            if (!ib & ob)
                c++;
        }
        return c;
    }

    static bool SupportTls(ReadOnlySpan<char> span)
    {
        for (int i = 3; i < span.Length; i++)
        {
            if (span[i - 3] == span[i] && span[i - 2] == span[i - 1] && span[i] != span[i - 1])
                return true;
        }
        return false;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int c = 0;
        HashSet<string> supernetSequences = new(), hypernetSequences = new();
        foreach (var line in span.EnumerateLines())
        {
            supernetSequences.Clear();
            hypernetSequences.Clear();
            var isSupernet = line[0] != '[';
            foreach (var item in line.EnumerateSlices("[]"))
            {
                if (isSupernet)
                    SearchSsl(item, supernetSequences);
                else
                    SearchSsl(item, hypernetSequences); ;
                isSupernet = !isSupernet;
            }
            if (supernetSequences.Any(x => hypernetSequences.SingleOrDefault(t => t[0] == x[1] && t[1] == x[0]) != null))
                c++;
        }
        return c;
    }

    static void SearchSsl(ReadOnlySpan<char> span, HashSet<string> f)
    {
        for (int i = 2; i < span.Length; i++)
        {
            if (span[i - 2] == span[i] && span[i - 1] != span[i])
                f.Add(span.Slice(i - 2, 3).ToString());
        }
    }
}
