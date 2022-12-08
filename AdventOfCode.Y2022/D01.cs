namespace AdventOfCode.Y2022;

public class D01 : IDay<int>
{
    public int Year => 2022;

    public int Day => 1;

    public string Title => "Calorie Counting";

    public int Part1(ReadOnlySpan<char> span) => TopTotalCalories(span, 1);

    public int Part2(ReadOnlySpan<char> span) => TopTotalCalories(span, 3);

    static int TopTotalCalories(ReadOnlySpan<char> span, int count)
    {
        Span<int> maxCalories = stackalloc int[count];
        var calories = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (item.IsEmpty)
            {
                if (calories > maxCalories[0])
                {
                    maxCalories[0] = calories;
                    maxCalories.Sort();
                }
                calories = 0;
            }
            else
            {
                calories += int.Parse(item);
            }
        }
        return maxCalories.Sum();
    }
}
