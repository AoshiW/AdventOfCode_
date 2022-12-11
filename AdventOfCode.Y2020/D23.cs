namespace AdventOfCode.Y2020;

public class D23 : IDay<long>
{
    public int Year => 2020;

    public int Day => 23;

    public string Title => "Crab Cups";

    public long Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        var buffer = new long[3];
        for (int i = 0; i < 100; i++)
        {
            var item = input[0];
            var io = item;
            input.CopyTo(1, buffer, 0, 3);
            input.RemoveRange(0, 4);
            do
            {
                if (--item == 0)
                {
                    item = 9;
                }
            }
            while (Array.IndexOf(buffer, item) != -1);
            int index = input.IndexOf(item);
            input.InsertRange(index + 1, buffer);
            input.Add(io);
        }
        var one = input.IndexOf(1);
        input.AddRange(input.Skip(one + 1).Take(8 - one));
        input.RemoveRange(one, 8 - one + 1);
        return input.Aggregate((a, b) => a * 10 + b);
    }

    static List<long> ParseInput(ReadOnlySpan<char> span)
    {
        var input = new List<long>();
        foreach (var item in span)
        {
            input.Add((long)char.GetNumericValue(item));
        }
        return input;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        var input = new LinkedList<long>(ParseInput(span));
        var dic = new Dictionary<long, LinkedListNode<long>>();
        foreach (var item in input)
        {
            dic.Add(item, input.Find(item)!);

        }
        for (int i = 10; i <= 1_000_000; i++)
        {
            dic.Add(i, input.AddLast(i));
        }
        var buffer = new List<LinkedListNode<long>>(3) { null!, null!, null! };
        for (int i = 0; i < 10_000_000; i++)
        {
            var item = input.First!.Value;
            var io = input.First;
            input.RemoveFirst();
            for (int ii = 0; ii < 3; ii++)
            {
                buffer[ii] = input.First;
                input.Remove(buffer[ii]);
            }
            do
            {
                if (--item == 0)
                {
                    item = 1_000_000;
                }
            }
            while (buffer.Any(x => x.Value == item));
            var index = dic[item];
            for (int ii = 2; ii >= 0; ii--)
            {
                input.AddAfter(index, buffer[ii]);
            }
            input.AddLast(io);
        }
        var one = dic[1].NextCircleNode();
        return one.Value * one.NextCircleNode().Value;
    }
}
