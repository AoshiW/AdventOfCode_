namespace AdventOfCode.Y2020;

public class D25 : IDay<long>
{
    /// <inheritdoc/>
    public int Year => 2020;

    /// <inheritdoc/>
    public int Day => 25;

    /// <inheritdoc/>
    public string Title => "Combo Breaker";

    /// <inheritdoc/>
    public long Part1(ReadOnlySpan<char> span)
    {
        Span<long> input = stackalloc long[2];
        var enumerator = span.EnumerateLines();
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            input[i] = long.Parse(enumerator.Current);
        }
        var loopSize = LoopSize(input[1]);
        return EncryptionKey(input[0], loopSize);
    }

    static long LoopSize(long key)
    {
        long loop = 0,
            value = 1;
        while (value != key)
        {
            value = value * 7 % 20_201_227;
            loop++;
        }
        return loop;
    }

    static long EncryptionKey(long publicKey, long size)
    {
        var key = 1L;
        for (var i = 0L; i < size; i++)
        {
            key = key * publicKey % 20_201_227;
        }
        return key;
    }

    /// <inheritdoc/>
    public long Part2(ReadOnlySpan<char> span) => default;
}
