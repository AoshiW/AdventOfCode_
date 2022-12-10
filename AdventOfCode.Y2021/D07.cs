namespace AdventOfCode.Y2021;

public class D07 : IDay<int>
{
    public int Year => 2021;

    public int Day => 7;

    public string Title => "The Treachery of Whales";

    public int Part1(ReadOnlySpan<char> span) => Part(span, static x => x);

    static (List<int> Nums, int Min, int Max) ParseInput(ReadOnlySpan<char> span)
    {
        var nums = new List<int>();
        int min = int.MaxValue, max = int.MinValue;
        foreach (var item in span.EnumerateSlices(","))
        {
            var num = int.Parse(item);
            if (num < min)
            {
                min = num;
            }
            else if (num > max)
            {
                max = num;
            }
            nums.Add(num);
        }
        return (nums, min, max);
    }

    static int Part(ReadOnlySpan<char> span, Func<int, int> func)
    {
        var input = ParseInput(span);
        int fuelMin = int.MaxValue;
        for (int i = input.Min; i < input.Max; i++)
        {
            int fuel = 0;
            foreach (var item in input.Nums)
            {
                fuel += func(Math.Abs(i - item));
                if (fuel > fuelMin)
                {
                    break;
                }
            }
            if (fuel < fuelMin)
                fuelMin = fuel;
        }
        return fuelMin;
    }

    public int Part2(ReadOnlySpan<char> span) => Part(span, static x =>
    {
        var fuel = 0;
        while (x != 0)
        {
            fuel += x--;
        }
        return fuel;
    });
}
