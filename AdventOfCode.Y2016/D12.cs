namespace AdventOfCode.Y2016;

public partial class D12 : IDay<int>
{
    public int Year => 2016;

    public int Day => 12;

    public string Title => "Leonardo's Monorail";

    public int Part1(ReadOnlySpan<char> span)
    {
        var pc = new PC(span);
        pc.Execute();
        return pc.Registers['a'];
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var pc = new PC(span);
        pc.Registers['c'] = 1;
        pc.Execute();
        return pc.Registers['a'];
    }
}
