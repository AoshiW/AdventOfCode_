namespace AdventOfCode.Y2015;

public partial class D16 : IDay<int>
{
    public int Year => 2015;

    public int Day => 16;

    public string Title => "Aunt Sue";

    public int Part1(ReadOnlySpan<char> span)
    {
        foreach (var item in span.EnumerateLines())
        {
            var aunt = ParseLine(item);
            if (aunt.Children is 3 or null
            && aunt.Cats is 7 or null
            && aunt.Samoyeds is 2 or null
            && aunt.Pomeranians is 3 or null
            && aunt.Akitas is 0 or null
            && aunt.Vizslas is 0 or null
            && aunt.Goldfish is 5 or null
            && aunt.Trees is 3 or null
            && aunt.Cars is 2 or null
            && aunt.Perfumes is 1 or null)
                return aunt.ID;
        }
        throw new ArgumentException(null, nameof(span));
    }

    static Aunt ParseLine(ReadOnlySpan<char> span)
    {
        var aunt = default(Aunt);
        var enumerator = span.EnumerateSlices(" :,");
        while (enumerator.MoveNext())
        {
            var key = enumerator.Current;
            enumerator.MoveNext();
            var value = int.Parse(enumerator.Current);
            if (key is "children") aunt.Children = value;
            else if (key is "cats") aunt.Cats = value;
            else if (key is "trees") aunt.Trees = value;
            else if (key is "pomeranians") aunt.Pomeranians = value;
            else if (key is "goldfish") aunt.Goldfish = value;
            else if (key is "samoyeds") aunt.Samoyeds = value;
            else if (key is "akitas") aunt.Akitas = value;
            else if (key is "vizslas") aunt.Vizslas = value;
            else if (key is "cars") aunt.Cars = value;
            else if (key is "perfumes") aunt.Perfumes = value;
            else aunt.ID = value;
        }
        return aunt;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        foreach (var item in span.EnumerateLines())
        {
            var aunt = ParseLine(item);
            if (aunt.Children is 3 or null
            && aunt.Cats is null or > 7
            && aunt.Trees is null or > 3
            && aunt.Pomeranians is null or < 3
            && aunt.Goldfish is null or < 5
            && aunt.Samoyeds is 2 or null
            && aunt.Akitas is 0 or null
            && aunt.Vizslas is 0 or null
            && aunt.Cars is 2 or null
            && aunt.Perfumes is 1 or null)
                return aunt.ID;
        }
        throw new ArgumentException(null, nameof(span));
    }
}
