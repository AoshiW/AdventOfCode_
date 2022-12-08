using System.Text;

namespace Kunc.AdventOfCode.Utils;

public static class SpanEnumeratorsExtensions
{
    public static SpanSliceEnumerator<T> EnumerateSlices<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> r, int skip = 0) where T : IEquatable<T>
    {
        var enumerator = new SpanSliceEnumerator<T>(span, r, true);
        for (int i = 0; i < skip; i++)
        {
            enumerator.MoveNext();
        }
        return enumerator;
    }

    public static SpanLineEnumerator EnumerateLines(this ReadOnlySpan<char> span, int skip)
    {
        var enumerator = span.EnumerateLines();
        for (int i = 0; i < skip; i++)
        {
            enumerator.MoveNext();
        }
        return enumerator;
    }
}
