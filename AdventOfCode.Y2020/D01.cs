namespace AdventOfCode.Y2020;

public class D01 : IDay<int>
{
    public int Year => 2020;

    public int Day => 1;

    public string Title => "Report Repair";

    public int Part1(ReadOnlySpan<char> span)
    {
        var nums = ParseInput(span);
        for (int i = 0; i < nums.Count; i++)
        {
            for (int ii = 0; ii < nums.Count; ii++)
            {
                if (ii == i)
                    continue;
                if (nums[i] + nums[ii] == 2020)
                    return nums[i] * nums[ii];
            }
        }
        throw new ArgumentException(null, nameof(span));
    }

    static List<int> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<int>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(int.Parse(item));
        }
        return list;
    }
    
    public int Part2(ReadOnlySpan<char> span)
    {
        var nums = ParseInput(span);
        for (int i = 0; i < nums.Count; i++)
        {
            for (int ii = 0; ii < nums.Count; ii++)
            {
                for (int iii = 0; iii < nums.Count; iii++)
                {
                    if (ii == i)
                        continue;
                    if (nums[i] + nums[ii] + nums[iii] == 2020)
                        return nums[i] * nums[ii] * nums[iii];
                }
            }
        }
        throw new ArgumentException(null, nameof(span));
    }
}
