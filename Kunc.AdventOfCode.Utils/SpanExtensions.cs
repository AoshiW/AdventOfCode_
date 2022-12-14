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

    public static void RotateRight<T>(this Span<T> span, int count, Span<T> buffer) where T : struct
    {
        var i = span.Length - count;
        span.Slice(i).CopyTo(buffer);
        span.Slice(0, i).CopyTo(span.Slice(count));
        buffer.Slice(0, count).CopyTo(span);
    }
    public static void RotateLeft<T>(this Span<T> span, int count, Span<T> buffer) where T : struct
    {
        RotateRight(span, span.Length - count, buffer);
    }
}
