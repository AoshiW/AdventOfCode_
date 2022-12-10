namespace AdventOfCode.Y2021;

public partial class D18 : IDay<int>
{
    public int Year => 2021;

    public int Day => 18;

    public string Title => "Snailfish";

    public int Part1(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines(1);
        var sn = SnailNumber.Parse(enumerator.Current, null);
        foreach (var item in enumerator)
        {
            sn += SnailNumber.Parse(item, null);
        }
        return sn.GetMagnitude();
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var numbers = new List<SnailNumber>();
        foreach (var item in span.EnumerateLines())
        {
            numbers.Add(SnailNumber.Parse(item, null));
        }
        int max = 0;
        for (int i1 = 0; i1 < numbers.Count; i1++)
        {
            var sn1 = numbers[i1];
            for (int i2 = i1 + 1; i2 < numbers.Count; i2++)
            {
                var sn2 = numbers[i2];
                var magnitude = (sn1 + sn2).GetMagnitude();
                if (magnitude > max)
                    max = magnitude;
                magnitude = (sn2 + sn1).GetMagnitude();
                if (magnitude > max)
                    max = magnitude;
            }
        }
        return max;
    }
}
