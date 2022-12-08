#pragma warning disable IDE0180 // Prohození hodnot pomocí řazené kolekce členů

namespace AdventOfCode.Y2022;

public class D03 : IDay<int>
{
    public int Year => 2022;

    public int Day => 3;

    public string Title => "Rucksack Reorganization";

    public int Part1(ReadOnlySpan<char> span)
    {
        int prioritySum = 0;
        foreach (var item in span.EnumerateLines())
        {
            var rucksackPart1 = item.Slice(0, item.Length / 2);
            var rucksackPart2 = item.Slice(item.Length / 2);
            foreach (var c in rucksackPart1)
            {
                if (rucksackPart2.Contains(c))
                {
                    prioritySum += char.IsLower(c)
                        ? c - 'a' + 1
                        : c - 'A' + 1 + 26;
                    break;

                };
            }
        }
        return prioritySum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int prioritySum = 0;
        var enumerator = span.EnumerateLines();
        while (enumerator.MoveNext())
        {
            var rucksack1 = enumerator.Current;
            enumerator.MoveNext();
            var rucksack2 = enumerator.Current;
            enumerator.MoveNext();
            var rucksack3 = enumerator.Current;
            if (rucksack2.Length > rucksack1.Length)
            {
                var temp = rucksack1;
                rucksack1 = rucksack2;
                rucksack2 = temp;
            }
            if (rucksack3.Length > rucksack1.Length)
            {
                var temp = rucksack1;
                rucksack1 = rucksack3;
                rucksack3 = temp;
            }
            foreach (var c in rucksack1)
            {
                if (rucksack2.Contains(c) && rucksack3.Contains(c))
                {
                    prioritySum += char.IsLower(c)
                        ? c - 'a' + 1
                        : c - 'A' + 1 + 26;
                    break;

                };
            }
        }
        return prioritySum;
    }
}
