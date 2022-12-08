namespace AdventOfCode.Y2016;

public sealed partial class D15 : IDay<int>
{
    public int Year => 2016;

    public int Day => 15;

    public string Title => "Timing is Everything";

    public int Part1(ReadOnlySpan<char> span) => Compute(span, false);

    static bool Test(ReadOnlySpan<Disc> discs)
    {
        for (int i = 0; i < discs.Length; i++)
        {
            var item = discs[i];
            if ((item.position + i + 1) % item.Positions != 0)
                return false;
        }
        return true;
    }

    public int Part2(ReadOnlySpan<char> span) => Compute(span, true);

    static int Compute(ReadOnlySpan<char> span, bool addNext)
    {
        var data = new List<Disc>();
        foreach (var item in span.EnumerateLines())
        {
            var dto = new Disc();
            var mItem = item.Slice(item.IndexOf("has ") + 4);
            var index = mItem.IndexOf(' ');
            dto.Positions = int.Parse(mItem.Slice(0, index));
            index = mItem.LastIndexOf(' ');
            dto.position = int.Parse(mItem.Slice(index).TrimEnd('.'));
            data.Add(dto);
        }
        if (addNext)
            data.Add(new() { Positions = 11 });
        var dataSpan = data.AsSpan();
        int t = 0;
        while (!Test(dataSpan))
        {
            t++;
            foreach (ref var item in dataSpan)
            {
                if (++item.position == item.Positions)
                    item.position = 0;
            }

        }
        return t;
    }
}
