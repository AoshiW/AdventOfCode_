using System.Text.RegularExpressions;

namespace AdventOfCode.Y2020;

public class D04 : IDay<int>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 4;

    /// <inheritdoc/>
    public string Title => "Passport Processing";

    /// <inheritdoc/>
    public int Part1(ReadOnlySpan<char> span)
    {
        int valid = 0;
        var dic = new Dictionary<string, bool>()
        {
            { "byr:", false },
            { "iyr:", false },
            { "eyr:", false },
            { "hgt:", false },
            { "hcl:", false },
            { "ecl:", false },
            { "pid:", false }
        };
        foreach (var item in span.EnumerateLines())
        {
            if (item.Length == 0)
            {
                if (dic.Values.Count(x => x) == dic.Count)
                    valid++;
                foreach (var key in dic.Keys)
                {
                    dic[key] = false;
                }
                continue;
            }
            foreach (var key in dic.Keys)
            {
                if (item.Contains(key, StringComparison.OrdinalIgnoreCase))
                    dic[key] = true;
            }
        }
        if (dic.Count(x => x.Value) == dic.Count)
            valid++;
        return valid;
    }

    static readonly HashSet<string> eyeColors = new()
    {
        "amb",
        "blu",
        "brn",
        "gry",
        "grn",
        "hzl",
        "oth"
    };

    /// <inheritdoc/>
    public int Part2(ReadOnlySpan<char> span)
    {
        var valid = 0;
        var validItem = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (item.Length == 0)
            {
                if (validItem == 7)
                    valid++;
                validItem = 0;
            }
            var refItem = item;
            while (TryParseData(ref refItem, out var key, out var value))
            {
                if (key.Equals("byr", StringComparison.OrdinalIgnoreCase))
                {
                    var byr = int.Parse(value);
                    if (byr.IsInRange(1920, 2003))
                        validItem++;
                }
                else if (key.Equals("iyr", StringComparison.OrdinalIgnoreCase))
                {
                    var iyr = int.Parse(value);
                    if (iyr.IsInRange(2010, 2021))
                        validItem++;
                }
                else if (key.Equals("eyr", StringComparison.OrdinalIgnoreCase))
                {
                    var eyr = int.Parse(value);
                    if (eyr.IsInRange(2020, 2031))
                        validItem++;
                }
                else if (key.Equals("hgt", StringComparison.OrdinalIgnoreCase))
                {
                    if (!int.TryParse(value.Slice(0, value.Length - 2), out var hgt))
                    {
                        continue;
                    }
                    var j = value.Slice(value.Length - 2);
                    if (j.Equals("cm", StringComparison.OrdinalIgnoreCase))
                    {
                        if (hgt.IsInRange(150, 194))
                            validItem++;
                    }
                    else if (j.Equals("in", StringComparison.OrdinalIgnoreCase))
                    {
                        if (hgt.IsInRange(59, 77))
                            validItem++;
                    }
                }
                else if (key.Equals("hcl", StringComparison.OrdinalIgnoreCase))
                {
                    if (value.Length == 7 && Regex.IsMatch(value.ToString(), "^#[1234567890abcdef]*$"))
                        validItem++;
                }
                else if (key.Equals("ecl", StringComparison.OrdinalIgnoreCase))
                {
                    if (eyeColors.Contains(value.ToString()))
                        validItem++;
                }
                else if (key.Equals("pid", StringComparison.OrdinalIgnoreCase))
                {
                    if (value.Length == 9 && int.TryParse(value, out var _))
                        validItem++;
                }
            }
        }
        if (validItem == 7)
            valid++;
        return valid;
    }

    private static bool TryParseData(ref ReadOnlySpan<char> item, out ReadOnlySpan<char> key, out ReadOnlySpan<char> value)
    {
        if (item.Length == 0)
        {
            key = value = default;
            return false;
        }
        var ki = item.IndexOf(':');
        key = item.Slice(0, ki);
        var vi = item.IndexOf(' ');
        if (vi == -1)
        {
            value = item.Slice(ki + 1);
            item = default;
        }
        else
        {
            value = item.Slice(ki + 1, vi - ki - 1);
            item = item.Slice(vi + 1);
        }
        return true;
    }
}
