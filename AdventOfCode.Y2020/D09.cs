namespace AdventOfCode.Y2020;

public class D09 : IDay<long>
{
    public int Year => 2020;

    public int Day => 9;

    public string Title => "Encoding Error";

    public long Part1(ReadOnlySpan<char> span)
    {
        var nums = ParseInput(span);
        for (int i = 25; i < nums.Count; i++)
        {
            if (!Compute(i - 25, nums[i]))
                return nums[i];
        }
        return -1;

        bool Compute(int min, long max)
        {
            for (int i = min; i < min + 25; i++)
            {
                for (int i2 = min; i2 < min + 25; i2++)
                {
                    if (i != i2 && max == nums[i] + nums[i2])
                        return true;
                }
            }
            return false;
        }
    }

    static List<long> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<long>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(long.Parse(item));
        }
        return list;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        var numss = ParseInput(span);
        var nums = new List<long>();
        var num = Part1(span);
        for (int i = 0; i < numss.Count; i++)
        {
            if (nums.Sum() < num)
            {
                nums.Add(numss[i]);
            }
            while (nums.Sum() > num)
            {
                nums.RemoveAt(0);
            }
            if (nums.Sum() == num)
            {
                return nums.Min() + nums.Max();
            }
        }
        return -1;
    }
}
