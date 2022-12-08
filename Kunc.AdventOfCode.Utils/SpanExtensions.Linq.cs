using System.Numerics;

namespace Kunc.AdventOfCode.Utils;
public static partial class SpanExtensions
{
    public static TAccumulate Aggregate<TSource, TAccumulate>(this ReadOnlySpan<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
    {
        ArgumentNullException.ThrowIfNull(nameof(func));

        TAccumulate result = seed;
        foreach (TSource element in source)
        {
            result = func(result, element);
        }

        return result;
    }

    public static T? Find<T>(this ReadOnlySpan<T> source, Predicate<T> match)
    {
        ArgumentNullException.ThrowIfNull(nameof(match));
        foreach (var item in source)
        {
            if (match(item))
                return item;
        }
        return default;
    }

    public static T? Find<T>(this Span<T> source, Predicate<T> match)
        => Find((ReadOnlySpan<T>)source, match);

    public static bool Any<T>(this ReadOnlySpan<T> source, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(nameof(predicate));
        foreach (var item in source)
        {
            if (predicate(item))
                return true;
        }
        return false;
    }

    public static bool Any<T>(this Span<T> source, Predicate<T> predicate)
        => Any((ReadOnlySpan<T>)source, predicate);
    public static T Sum<T>(this ReadOnlySpan<T> source) where T : INumberBase<T>
    {
        var sum = T.Zero;
        foreach (var item in source)
        {
            sum += item;
        }
        return sum;
    }
    public static T Sum<T>(this Span<T> source) where T : INumberBase<T>
        => Sum((ReadOnlySpan<T>)source);
}
