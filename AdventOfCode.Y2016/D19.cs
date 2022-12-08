namespace AdventOfCode.Y2016;

public class D19 : IDay<int>
{
    public int Year => 2016;

    public int Day => 19;

    public string Title => "An Elephant Named Joseph";

    public int Part1(ReadOnlySpan<char> span)
    {
        var num = int.Parse(span) + 1;
        var elf = new LinkedList<int>();
        for (var i = 1; i < num; i++)
        {
            elf.AddLast(i);
        }
        var node = elf.First!;
        while (elf.Count > 1)
        {
            elf.Remove(node.NextCircleNode());
            node = node.NextCircleNode();
        }
        return elf.First!.Value;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var num = int.Parse(span) + 1;
        var elf = new LinkedList<int>();
        for (int i = 0; i < num; i++)
        {
            elf.AddLast(i);
        }
        var node = elf.First;
        for (int i = 0; i < elf.Count / 2; i++)
        {
            node = node!.Next;
        }
        while (elf.Count > 1)
        {
            var temp = node!.NextCircleNode();
            elf.Remove(node!);
            node = temp;
            if ((elf.Count & 1) == 0)
            {
                node = node.NextCircleNode();
            }
        }
        return elf.First!.Value;
    }
}
