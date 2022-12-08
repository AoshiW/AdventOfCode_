namespace AdventOfCode.Y2016;

public class D23 : IDay<int>
{
    public int Year => 2016;

    public int Day => 23;

    public string Title => "Safe Cracking";

    public int Part1(ReadOnlySpan<char> span)
    {
        var pc = new D12.PC(span);
        pc.Registers['a'] = 7;
        pc.Execute();
        return pc.Registers['a'];
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var pc = new D12.PC(span);
        pc.Registers['a'] = 12;
        pc.Execute();
        return pc.Registers['a'];
    }
}
