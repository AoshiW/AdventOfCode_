using System.Diagnostics;
using System.Text.Json;

namespace AdventOfCode.Y2022;

public class D13 : IDay<int>
{
    public int Year => 2022;

    public string Title => "Distress Signal";

    public int Day => 13;

    public int Part1(ReadOnlySpan<char> span)
    {
        var correct = 0;
        var enumerator = span.EnumerateLines();
        for (int i = 1; enumerator.MoveNext(); i++)
        {
            var left = JsonSerializer.Deserialize<JsonElement>(enumerator.Current);
            enumerator.MoveNext();
            var right = JsonSerializer.Deserialize<JsonElement>(enumerator.Current);
            enumerator.MoveNext();
            if (Compare(left, right) >= 0)
                correct += i;
        }
        return correct;
    }

    static int Compare(JsonElement left, JsonElement right)
    {
        if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Number)
        {
            var lNumber = left.GetInt32();
            var rNumber = right.GetInt32();
            return rNumber.CompareTo(lNumber);
        }
        if (left.ValueKind == JsonValueKind.Array && right.ValueKind == JsonValueKind.Array)
        {
            var lArray = left.EnumerateArray();
            var rArray = right.EnumerateArray();
            bool lMove, rMove;
            while ((lMove = lArray.MoveNext()) & (rMove = rArray.MoveNext()))
            {
                var test = Compare(lArray.Current, rArray.Current);
                if (test != 0)
                    return test;
            }
            return (lMove, rMove) switch
            {
                (false, true) => 1,
                (false, false) => 0,
                (true, false) => -1,
                _ => throw new UnreachableException()
            };
        }
        Span<char> json = stackalloc char[8];
        JsonElement lNode, rNode;
        if (left.ValueKind == JsonValueKind.Number)
        {
            var lNumber = left.GetInt32();
            json.TryWrite($"[{lNumber}]", out var charsWritten);
            lNode = JsonSerializer.Deserialize<JsonElement>(json.Slice(0, charsWritten));
            rNode = right;
        }
        else
        {
            var rNumber = right.GetInt32();
            json.TryWrite($"[{rNumber}]", out var charsWritten);
            lNode = left;
            rNode = JsonSerializer.Deserialize<JsonElement>(json.Slice(0, charsWritten));
        }
        return Compare(lNode, rNode);
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var p1 = JsonSerializer.Deserialize<JsonElement>("[[2]]");
        var p2 = JsonSerializer.Deserialize<JsonElement>("[[6]]");
        var all = new List<JsonElement>(320)
        {
            p1, p2
        };
        foreach (var item in span.EnumerateLines())
        {
            if (!item.IsEmpty)
                all.Add(JsonSerializer.Deserialize<JsonElement>(item));
        }
        all.Sort(Compare);
        all.Reverse();
        return (all.IndexOf(p1) + 1) * (all.IndexOf(p2) + 1);
    }
}
