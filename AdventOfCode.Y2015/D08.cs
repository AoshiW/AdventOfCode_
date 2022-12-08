namespace AdventOfCode.Y2015;

public class D08 : IDay<int>
{
    public int Year => 2015;

    public int Day => 8;

    public string Title => "Matchsticks";

    public int Part1(ReadOnlySpan<char> span)
    {
        int sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            var isEscaped = false;
            int hex = 0;
            sum += 2;
            for (int i = 1; i < item.Length - 1; i++)
            {
                var c = item[i];
                if (isEscaped)
                {
                    sum++;
                    if (hex == 0)
                    {
                        if (c == 'x')
                        {
                            hex++;
                        }
                        else
                        {
                            isEscaped = false;
                        }
                    }
                    else
                    {
                        if (++hex == 3)
                        {
                            isEscaped = false;
                            hex = 0;
                        }
                    }
                }
                else
                {
                    if (c == '\\')
                    {
                        isEscaped = true;
                    }
                }
            }
        }
        return sum;
    }
    
    public int Part2(ReadOnlySpan<char> span)
    {
        int sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            var isEscaped = false;
            int hex = 0;
            sum += 4;
            for (int i = 1; i < item.Length - 1; i++)
            {
                var c = item[i];
                if (isEscaped)
                {
                    if (hex == 0)
                    {
                        if (c == 'x')
                        {
                            hex++;
                        }
                        else
                        {
                            sum++;
                            isEscaped = false;
                        }
                    }
                    else
                    {
                        if (++hex == 3)
                        {
                            isEscaped = false;
                            hex = 0;
                        }
                    }
                }
                else
                {
                    if (c == '\\')
                    {
                        sum++;
                        isEscaped = true;
                    }
                }
            }
        }
        return sum;
    }
}
