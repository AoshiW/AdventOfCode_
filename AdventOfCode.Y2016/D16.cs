namespace AdventOfCode.Y2016;

public class D16 : IDay<string>
{
    public int Year => 2016;

    public int Day => 16;

    public string Title => "Dragon Checksum";

    public string Part1(ReadOnlySpan<char> span) => Checksum(span, 272);

    static string Checksum(ReadOnlySpan<char> span, int length)
    {
        Span<char> temp = new char[length];
        span.CopyTo(temp);
        var count = span.Length;
        while (count < length)
        {
            var init = temp.Slice(0, count);
            temp[count++] = '0';
            for (int i = init.Length - 1; i >= 0 && count != temp.Length; i--)
            {
                temp[count++] = init[i] == '1' ? '0' : '1';
            }
        }
        do
        {
            for (int i = 0; i < length; i += 2)
            {
                temp[i / 2] = temp[i] == temp[i + 1] ? '1' : '0';
            }
            length /= 2;
        } while ((length & 1) == 0);
        return new string(temp.Slice(0, length));
    }

    public string Part2(ReadOnlySpan<char> span) => Checksum(span, 35651584);
}
