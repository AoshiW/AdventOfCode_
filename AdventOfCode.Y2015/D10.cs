using System.Text;

namespace AdventOfCode.Y2015;

public class D10 : IDay<int>
{
    public int Year => 2015;

    public int Day => 10;

    public string Title => "lves Look, Elves Say";

    public int Part1(ReadOnlySpan<char> span) => Compute(span, 40);

    static int Compute(ReadOnlySpan<char> span, int count)
    {
        StringBuilder input = new(), sb = new();
        input.Append(span);
        for (int ir = 0; ir < count; ir++)
        {
            char c = input[0];
            int cCount = 1;
            sb.Length = 0;
            for (var i = 1; i < input.Length; i++)
            {
                if (c != input[i])
                {
                    sb.Append(cCount).Append(c);
                    c = input[i];
                    cCount = 1;
                }
                else
                    cCount++;
            }
            sb.Append(cCount).Append(c);
            (sb, input) = (input, sb);
        }
        return input.Length;
    }

    public int Part2(ReadOnlySpan<char> span) => Compute(span, 50);
}
