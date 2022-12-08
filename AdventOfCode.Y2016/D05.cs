using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2016;

public class D05 : IDay<string>
{
    public int Year => 2016;

    public int Day => 5;

    public string Title => "How About a Nice Game of Chess?";

    public string Part1(ReadOnlySpan<char> span) => GetPassword(span, static c => c[^1] == '\0', static (b, c) =>
    {
        c[c.IndexOf('\0')] = (b[2] & 0xF).ToHex();
    });

    public string Part2(ReadOnlySpan<char> span) => GetPassword(span, static c => c.IndexOf('\0') != -1, static (b, c) =>
    {
        var index = (int)char.GetNumericValue((b[2] & 0xf).ToHex());
        if (index.IsInRange(0, 8) && c[index] == '\0')
            c[index] = (b[3] >> 4).ToHex();
    });

    delegate void SA(Span<byte> span, Span<char> chars);

    static string GetPassword(ReadOnlySpan<char> span, ReadOnlySpanFunc<char, bool> predicate, SA action)
    {
        Span<char> str = stackalloc char[span.Length + MagicNumbers.MaxStringLengthFor<int>()];
        Span<byte> encodedBytes = stackalloc byte[str.Length];
        span.CopyTo(str);
        var numstr = str.Slice(span.Length);
        Span<char> code = stackalloc char[8];
        Span<byte> hashBytes = stackalloc byte[MagicNumbers.MD5HashByteCount];
        for (int i = 0; predicate(code); i++)
        {
            i.TryFormat(numstr, out var written);
            written = Encoding.ASCII.GetBytes(str.Slice(0, written + span.Length), encodedBytes);
            MD5.HashData(encodedBytes.Slice(0, written), hashBytes);
            if (hashBytes[0] == 0 && hashBytes[1] == 0 && (hashBytes[2] & 0xf0) == 0)
            {
                action(hashBytes, code);
            }
        }
        return new string(code);
    }
}
