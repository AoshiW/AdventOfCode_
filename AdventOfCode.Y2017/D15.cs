using Kunc.AdventOfCode;
using System;

namespace AdventOfCode.Y2017;

public class D15 : IDay<int>
{
    public int Year => 2017;

    public int Day => 15;

    public string Title => "Dueling Generators";

    public int Part1(ReadOnlySpan<char> span)
    {
        Span<long> nums = stackalloc long[2];
        ParseInput(span, nums);
        int count = 0;
        for (var i = 0; i < 40_000_000; i++)
        {
            nums[0] = nums[0] * 16807 % int.MaxValue;
            nums[1] = nums[1] * 48271 % int.MaxValue;
            if ((nums[0] & ushort.MaxValue) == (nums[1] & ushort.MaxValue))
                count++;
        }
        return count;
    }

    static void ParseInput(ReadOnlySpan<char> span, Span<long> destination)
    {
        int i = 0;
        foreach (var item in span.EnumerateLines())
        {
            destination[i++] = long.Parse(item.Slice(item.LastIndexOf(' ') + 1));
        }
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        Span<long> nums = stackalloc long[2];
        ParseInput(span, nums);
        int count = 0;
        for (var i = 0; i < 5_000_000; i++)
        {
            do
            {
                nums[0] = nums[0] * 16807 % int.MaxValue;
            } while ((nums[0] % 4) != 0);
            do
            {
                nums[1] = nums[1] * 48271 % int.MaxValue;
            } while ((nums[1] % 8) != 0);
            if ((nums[0] & ushort.MaxValue) == (nums[1] & ushort.MaxValue))
                count++;
        }
        return count;
    }
}
