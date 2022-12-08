using System.Text.Json;

namespace AdventOfCode.Y2015;

public class D12 : IDay<int>
{
    public int Year => 2015;

    public int Day => 12;

    public string Title => "JSAbacusFramework.io";

    public int Part1(ReadOnlySpan<char> span)
    {
        var json = JsonSerializer.Deserialize<JsonElement>(span);
        return GetSum(json);
    }

    static int GetSum(in JsonElement node)
    {
        int sum = 0;
        if (node.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in node.EnumerateArray())
            {
                sum += GetSum(item);
            }
        }
        else if (node.ValueKind == JsonValueKind.Object)
        {
            foreach (var item in node.EnumerateObject())
            {
                sum += GetSum(item.Value);
            }
        }
        else if (node.ValueKind == JsonValueKind.Number)
        {
            node.TryGetInt32(out sum);
        }
        return sum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var json = JsonSerializer.Deserialize<JsonElement>(span);
        return GetSum2(json!)!.Value;
    }

    static int? GetSum2(in JsonElement node)
    {
        int sum = 0;
        if (node.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in node.EnumerateArray())
            {
                sum += GetSum2(item) ?? 0;
            }
        }
        else if (node.ValueKind == JsonValueKind.Object)
        {
            foreach (var item in node.EnumerateObject())
            {
                var val = GetSum2(item.Value);
                if (val is null)
                {
                    return 0;
                }
                sum += val.Value;
            }
        }
        else if (node.ValueKind == JsonValueKind.Number)
        {
            node.TryGetInt32(out sum);
        }
        else if (node.ValueEquals("red"u8))
        {
            return null;
        }
        return sum;
    }
}
