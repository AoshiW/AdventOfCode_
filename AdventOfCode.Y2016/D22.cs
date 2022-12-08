namespace AdventOfCode.Y2016;

public class D22 : IDay<int>
{
    public int Year => 2016;

    public int Day => 22;

    public string Title => "Grid Computing";

    public int Part1(ReadOnlySpan<char> span)
    {
        var nodes = new List<(int Used, int Avail)>();
        foreach (var item in span.EnumerateLines(2))
        {
            var enumerator = item.EnumerateSlices(" T", 3);
            var used = int.Parse(enumerator.Current);
            enumerator.MoveNext();
            var avail = int.Parse(enumerator.Current);
            nodes.Add((used, avail));
        }
        int match = 0;
        for (int i = 0; i < nodes.Count; i++)
        {
            var nodeA = nodes[i];
            for (int ii = 0; ii < nodes.Count; ii++)
            {
                var nodeB = nodes[ii];
                if (i != ii && nodeA.Used <= nodeB.Avail && nodeA.Used != 0)
                    match++;
            }
        }
        return match;
    }

    public int Part2(ReadOnlySpan<char> span) => throw new NotImplementedException();
}
