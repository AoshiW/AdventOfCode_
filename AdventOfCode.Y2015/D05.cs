namespace AdventOfCode.Y2015;

public class D05 : IDay<int>
{
    public int Year => 2015;

    public int Day => 5;

    public string Title => "Doesn't He Have Intern-Elves For This?";

    public int Part1(ReadOnlySpan<char> span) => NiceCounter(span, static item => AtLeastThreeVowels(item) && TwoInRow(item) && NotContain(item));

    static int NiceCounter(ReadOnlySpan<char> span, ReadOnlySpanFunc<char, bool> predicate)
    {
        int nice = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (predicate(item))
                nice++;
        }
        return nice;
    }

    static bool AtLeastThreeVowels(ReadOnlySpan<char> span)
    {
        int count = 0;
        foreach (var item in span)
        {
            if ("aeiou".Contains(item) && ++count > 2)
                return true;
        }
        return false;
    }

    static bool TwoInRow(ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length - 1; i++)
            if (span[i] == span[i + 1])
                return true;
        return false;
    }

    static readonly string[] ForbiddenPairs = new[] { "ab", "cd", "pq", "xy" };

    static bool NotContain(ReadOnlySpan<char> span)
    {
        foreach (var item in ForbiddenPairs)
        {
            if (span.Contains(item, StringComparison.OrdinalIgnoreCase))
                return false;
        }
        return true;
    }

    public int Part2(ReadOnlySpan<char> span) => NiceCounter(span, static item => TwoOverOne(item) && PairOfTwoLetters(item));

    static bool TwoOverOne(ReadOnlySpan<char> span)
    {
        for (int i = 2; i < span.Length; i++)
        {
            if (span[i] == span[i - 2])
                return true;
        }
        return false;
    }

    static bool PairOfTwoLetters(ReadOnlySpan<char> span)
    {
        for (int i = 2; i < span.Length; i++)
        {
            if (span.Slice(i).Contains(span.Slice(i - 2, 2), StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}
