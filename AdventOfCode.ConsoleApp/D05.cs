using Kunc.AdventOfCode;
using System.Text;

public class D05 : IDay<int>
{
    public int Year => 2018;
    public string Title => "Alchemical Reduction";
    public int Day => 5;

    public int Part1(ReadOnlySpan<char> span)
    {
        var sb = new StringBuilder().Append(span); ;
        bool react = true;
        while (react)
        {
            react = false;
            for (int i = 1; i < sb.Length; i++)
            {
                if (sb[i - 1] - sb[i] is 32 or -32)
                {
                    sb.Remove(i - 1, 2);
                    react = true;
                }
            }
        }
        return sb.Length;
    }
    public int Part2(ReadOnlySpan<char> span)
    {
        int min = int.MaxValue;
        var sb = new StringBuilder();
        for (var c = 'a'; c <= 'z'; c++)
        {
            sb.Clear().Append(span)
                .Replace(c.ToString(), "")
                .Replace(char.ToUpper(c).ToString(), "");
            bool react = true;
            while (react)
            {
                react = false;
                for (int i = 1; i < sb.Length; i++)
                {
                    if (sb[i - 1] - sb[i] is 32 or -32)
                    {
                        sb.Remove(i - 1, 2);
                        react = true;
                    }
                }
            }
            if (sb.Length < min)
                min = sb.Length;
        }
        return min;
    }
}
