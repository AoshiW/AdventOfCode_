using System.Numerics;

namespace Kunc.AdventOfCode.Utils;

public static class MultidimensionalArrayExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this T[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        foreach (var item in array)
        {
            yield return item;
        }
    }

    public static T Sum<T>(this T[,] array) where T : INumberBase<T>
    {
        ArgumentNullException.ThrowIfNull(array);
        T sum = T.Zero;
        foreach (var item in array)
        {
            sum += item;
        }
        return sum;
    }

    public static int Count<T>(this T[,] array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(predicate);
        int sum = 0;
        foreach (var item in array)
        {
            if (predicate(item))
                sum++;
        }
        return sum;
    }

    public static IEnumerable<IEnumerable<T>> GetSection<T>(this T[,] source, int rowFrom, int rowTo, int collFrom, int collTo)
    {
        ArgumentNullException.ThrowIfNull(source);
        for (; rowFrom < rowTo; rowFrom++)
        {
            yield return GetColumn();
        }

        IEnumerable<T> GetColumn()
        {
            var i = collFrom;
            for (; i < collTo; i++)
            {
                yield return source[rowFrom, i];
            }
        }
    }
}
