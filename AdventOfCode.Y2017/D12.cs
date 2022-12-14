namespace AdventOfCode.Y2017;

public partial class D12 : IDay<int>
{
    public int Year => 2017;

    public int Day => 12;

    public string Title => "Digital Plumber";

    public int Part1(ReadOnlySpan<char> span)
    {
        int count = 1;
        var input = ParseInput(span);
        var history = new HashSet<int>();
        for (int i = 1; i < input.Count; i++)
        {
            history.Clear();
            if (IsConected(i, input, history, 0))
                count++;
        }
        return count;
    }

    static List<Program> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<Program>();
        foreach (var item in span.EnumerateLines())
        {
            var subList = new List<int>(3);
            foreach (var item2 in item.EnumerateSlices(" ,<->", 1))
            {
                subList.Add(int.Parse(item2));
            }
            list.Add(new Program()
            {
                Id = list.Count,
                Pipes = subList
            });
        }
        return list;
    }

    static bool IsConected(int programId, List<Program> other, HashSet<int> history, int group)
    {
        if (!history.Add(programId))
            return false;
        var program = other.Find(x => x.Id == programId)!;
        if (program.Pipes.Contains(group))
            return true;
        foreach (var item in program.Pipes)
        {
            if (IsConected(item, other, history, group))
                return true;
        }
        return false;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int groups = 0;
        var input = ParseInput(span);
        var history = new HashSet<int>();
        var list = new List<int>();
        while (input.Count != 0)
        {
            list.Clear();
            list.Add(input[0].Id);
            for (int i = 1; i < input.Count; i++)
            {
                history.Clear();
                var item = input[i];
                if (IsConected(item.Id, input, history, input[0].Id))
                    list.Add(item.Id);
            }
            groups++;
            input.RemoveAll(x => list.Contains(x.Id));
        }
        return groups;
    }
}
