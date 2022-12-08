namespace Kunc.AdventOfCode;

public interface IDay
{
    public int Year { get; }
    public int Day { get; }
    public string Title { get; }

    public object? Part1(ReadOnlySpan<char> span);
    public object? Part2(ReadOnlySpan<char> span);
}

public interface IDay<T> : IDay
{
    /// <inheritdoc cref="IDay.Part1(ReadOnlySpan{char})"/>
    new public T Part1(ReadOnlySpan<char> span);

    /// <inheritdoc cref="IDay.Part2(ReadOnlySpan{char})"/>
    new public T Part2(ReadOnlySpan<char> span);

    object? IDay.Part1(ReadOnlySpan<char> span) => Part1(span);
    object? IDay.Part2(ReadOnlySpan<char> span) => Part2(span);
}
