using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Y2016;

public class D14 : IDay<int>
{
    public int Year => 2016;

    public int Day => 14;

    public string Title => "One-Time Pad";

    public int Part1(ReadOnlySpan<char> span) => Index(span, 0);

    static bool Check3(ReadOnlySpan<byte> bytes, out int num)
    {
        num = bytes[0] & 0xF;
        if (bytes[0] >> 4 == num && bytes[1] >> 4 == num)
            return true;
        for (int i = 1; i < bytes.Length - 1; i++)
        {
            num = bytes[i] & 0xF;
            if (num == bytes[i] >> 4 && (num == (bytes[i - 1] & 0xF) || bytes[i + 1] >> 4 == num))
            {
                return true;
            }
        }
        num = bytes[^1] & 0xF;
        return bytes[^1] >> 4 == num && (bytes[^2] & 0xF) == num;
    }

    static bool Check5(ReadOnlySpan<byte> bytes, out int num)
    {
        num = bytes[0] & 0xF;
        if (bytes[0] >> 4 == num && bytes[1] == bytes[0] && bytes[2] >> 4 == num)
            return true;
        for (int i = 1; i < bytes.Length - 2; i++)
        {
            num = bytes[i] & 0xF;
            if (num == bytes[i] >> 4 && bytes[i + 1] == bytes[i] && (num == (bytes[i - 1] & 0xF) || bytes[i + 2] >> 4 == num))
            {
                return true;
            }
        }
        num = bytes[^1] & 0xF;
        return bytes[^1] >> 4 == num && bytes[^1] == bytes[^2] && (bytes[^3] & 0xF) == num;
    }

    public int Part2(ReadOnlySpan<char> span) => Index(span, 2016);

    static int Index(ReadOnlySpan<char> span, int bonus)
    {
        var history = new List<(int In, int Value)>();
        Span<byte> hashBytes = stackalloc byte[32];
        Span<char> hahStr = stackalloc char[32];
        for (int index = 0, key = 0; ; index++)
        {
            span.CopyTo(hahStr);
            index.TryFormat(hahStr.Slice(span.Length), out var wc);
            MD5.HashData(hashBytes.Slice(0, Encoding.ASCII.GetBytes(hahStr.Slice(0, span.Length + wc), hashBytes)), hashBytes);
            var hashBytesCeck = hashBytes.Slice(0, 16);
            for (int additionalHashings = 0; additionalHashings < bonus; additionalHashings++)
            {
                hashBytesCeck.AsReadOnly().ToHexString(hahStr);
                Encoding.ASCII.GetBytes(hahStr, hashBytes);
                MD5.HashData(hashBytes, hashBytes);
            }
            if (Check3(hashBytesCeck, out var num))
            {
                history.Add((index, num));
                if (Check5(hashBytesCeck, out num))
                {
                    history.RemoveAll(x => x.In <= index - 1000);
                    var lastIndex = history.FindLastIndex(x => x.Value == num);
                    for (int ii = 0; ii < lastIndex ; ii++)
                    {
                        var item = history[ii];
                        if (item.Value == num)
                        {
                            if (++key == 64)
                                return item.In;
                            history.RemoveAt(ii);
                            lastIndex--;
                            ii--;
                        }
                    }
                }
            }
        }
    }
}
