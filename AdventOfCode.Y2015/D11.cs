namespace AdventOfCode.Y2015;

public class D11 : IDay<string>
{
    public int Year => 2015;

    public int Day => 11;

    public string Title => "Corporate Policy";

    public string Part1(ReadOnlySpan<char> span)
    {
        Span<char> input = stackalloc char[span.Length];
        span.CopyTo(input);
        while (!ValidateString(input))
        {
            UpdateString(input);
        }
        return new string(input);
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        Span<char> input = stackalloc char[span.Length];
        span.CopyTo(input);
        while (!ValidateString(input))
        {
            UpdateString(input);
        }
        do
        {
            UpdateString(input);
        }
        while (!ValidateString(input));
        return new string(input);
    }

    static void UpdateString(Span<char> str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] != 'z')
            {
                str[i]++;
                return;
            }
            str[i] = 'a';
        }
    }

    static bool ValidateString(Span<char> str)
    {
        bool p1 = false, p3 = false;
        for (int i = 0; i < str.Length - 2; i++)
        {
            if (str[i + 1] == str[i] + 1 && str[i + 2] == str[i] + 2)
            {
                p1 = true;
                break;
            }
        }
        if (str.IndexOfAny("ilo") != -1)
        {
            return false;
        }
        char c = 'o';
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (str[i] == str[i + 1])
            {
                if (c == 'o')
                {
                    c = str[i];
                }
                else if (str[i] != c)
                {
                    p3 = true;
                    break;
                }
            }
        }
        return p1 && p3;
    }
}
