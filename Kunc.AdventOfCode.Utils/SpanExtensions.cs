using System.Runtime.CompilerServices;

namespace Kunc.AdventOfCode.Utils;

public static partial class SpanExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<T> AsReadOnly<T>(this Span<T> span) => span;

    public static void ToHexString(this ReadOnlySpan<byte> souce, Span<char> destination, bool isUpper = false)
    {
        for (int i = 0; i < souce.Length; i++)
        {
            destination[i * 2] = (souce[i] >> 4).ToHex(isUpper);
            destination[i * 2 + 1] = (souce[i] & 0xF).ToHex(isUpper);
        }
    }
}
