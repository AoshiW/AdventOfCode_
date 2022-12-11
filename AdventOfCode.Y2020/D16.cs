namespace AdventOfCode.Y2020;

public class D16 : IDay<long>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 16;

    /// <inheritdoc/>
    public string Title => "Ticket Translation";

    /// <inheritdoc/>
    public long Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        return GetWrongTickets(input.NearbyTickets, input.Item1).Sum();
    }

    static List<int> GetWrongTickets(List<List<int>> nearbyTickets, List<(string, List<(int, int)>)> t)
    {
        var wringTickets = nearbyTickets.SelectMany(x => x).ToList();
        foreach (var item in t.SelectMany(x => x.Item2))
        {
            for (int i = item.Item1; i < item.Item2 + 1; i++)
            {

                wringTickets.Remove(i);
            }
        }
        return wringTickets;
    }

    static (List<(string, List<(int, int)>)>, List<int> YourTicket, List<List<int>> NearbyTickets) ParseInput(ReadOnlySpan<char> span)
    {
        var neco = new List<(string, List<(int, int)>)>();
        List<int> yourTicket = new();
        var enumerator = span.EnumerateLines();
        while (enumerator.MoveNext() && enumerator.Current.Length != 0)
        {
            ParseLines(enumerator.Current, ref neco);
        }
        enumerator.MoveNext();
        while (enumerator.MoveNext() && enumerator.Current.Length != 0)
        {
            foreach (var item in enumerator.Current.EnumerateSlices(","))
            {
                yourTicket.Add(int.Parse(item));
            }
        }
        enumerator.MoveNext();
        var nearbyTickets = new List<List<int>>();
        while (enumerator.MoveNext())
        {
            var tempNearbyTickets = new List<int>();
            foreach (var item in enumerator.Current.EnumerateSlices(","))
            {
                tempNearbyTickets.Add(int.Parse(item));
            }
            nearbyTickets.Add(tempNearbyTickets);
        }
        return (neco, yourTicket, nearbyTickets);
    }

    static void ParseLines(ReadOnlySpan<char> span, ref List<(string, List<(int, int)>)> result)
    {
        var list = new List<(int, int)>();
        var i = span.IndexOf(':');
        var name = span.Slice(0, i).ToString();
        span = span.Slice(i + 1);
        while (span.Length > 0)
        {
            i = span.IndexOf('-');
            var i1 = int.Parse(span.Slice(0, i));
            int i2;
            span = span.Slice(i + 1);
            i = span.IndexOf(' ');
            if (i == -1)
            {
                i2 = int.Parse(span);
                span = default;
            }
            else
            {
                i2 = int.Parse(span.Slice(0, i));
                span = span.Slice(i + 4);
            }
            list.Add((i1, i2));
        }
        result.Add((name, list));
    }

    /// <inheritdoc/>
    public long Part2(ReadOnlySpan<char> span) => throw new NotImplementedException();
}
