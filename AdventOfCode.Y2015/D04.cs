using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2015;

public class D04 : IDay<int>
{
    public int Year => 2015;

    public int Day => 4;

    public string Title => "The Ideal Stocking Stuffer";

    public int Part1(ReadOnlySpan<char> span) => AdventCoin(span, static bytes => bytes[0] == 0 & bytes[1] == 0 & (bytes[2] & 0xF0) == 0);

    public int Part2(ReadOnlySpan<char> span) => AdventCoin(span, static bytes => bytes[0] == 0 & bytes[1] == 0 & bytes[2] == 0);

    static int AdventCoin(ReadOnlySpan<char> span, ReadOnlySpanFunc<byte, bool> predicate)
    {
        Span<char> str = stackalloc char[span.Length + MagicNumbers.MaxStringLengthFor<int>()];
        span.CopyTo(str);
        var strNumber = str.Slice(span.Length);
        Span<byte> bytes = stackalloc byte[MagicNumbers.MD5HashByteCount]; // 16 bytes
        for (int i = 0; ; i++)
        {
            i.TryFormat(strNumber, out var written);
            var inputBytes = Encoding.ASCII.GetBytes(str.Slice(0, written + span.Length), bytes);
            MD5.HashData(bytes.Slice(0, inputBytes), bytes);
            if (predicate(bytes))
                return i;
        }
    }
}
