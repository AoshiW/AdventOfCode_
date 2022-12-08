namespace AdventOfCode.Y2015;

public class D20 : IDay<int>
{
    public int Year => 2015;

    public int Day => 20;

    public string Title => "Infinite Elves and Infinite Houses";

    public int Part1(ReadOnlySpan<char> span)
    {
        var input = int.Parse(span);
        var houses = new int[input / 40];
        for (int present = 1; present < houses.Length; present++)
        {
            for (int j = present; j < houses.Length; j += present)
            {
                houses[j] += present;
            }
        }
        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i] * 10 > input)
                return i;
        }
        return -1;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var input = int.Parse(span);
        var houses = new int[input / 40];
        for (int present = 1; present < houses.Length; present++)
        {
            for (int j = present, c = 0; c < 50 && j < houses.Length; j += present, c++)
            {
                houses[j] += present;
            }
        }
        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i] * 11 > input)
                return i;
        }
        return -1;
    }
}
