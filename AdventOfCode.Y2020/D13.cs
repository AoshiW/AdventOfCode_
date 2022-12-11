namespace AdventOfCode.Y2020;

public class D13 : IDay<long>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 13;

    /// <inheritdoc/>
    public string Title => "Shuttle Search";

    /// <inheritdoc/>
    public long Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        var ids = input.neco.Skip(1).Where(x => x is not null).Cast<int>().ToArray();
        int waitTime = ids.Min(x => x - input.Timestamp % x);
        var id = ids.First(x => x - input.Timestamp % x == waitTime);
        return waitTime * id;
    }

    static (int Timestamp, List<int?> neco) ParseInput(ReadOnlySpan<char> span)
    {
        var enumerator = span.EnumerateLines();
        enumerator.MoveNext();
        var timestamp = int.Parse(enumerator.Current);
        enumerator.MoveNext();
        span = enumerator.Current;
        var bu = new List<int?>();
        foreach (var item in enumerator.Current.EnumerateSlices(","))
        {
            if (int.TryParse(item, out var value))
            {
                bu.Add(value);
            }
            else
                bu.Add(null);
        }
        return (timestamp, bu);
    }

    /// <inheritdoc/>  
    public long Part2(ReadOnlySpan<char> span) => throw new NotImplementedException();
}
