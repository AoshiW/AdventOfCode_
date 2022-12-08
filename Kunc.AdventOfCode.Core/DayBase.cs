namespace Kunc.AdventOfCode;

public abstract class DayBase<T> : IDay<T>
{
    /// <inheritdoc/>
    public int Year { get; }

    /// <inheritdoc/>
    public int Day { get; }

    /// <inheritdoc/>
    public string Title { get; }

    public DayBase(int year, int day, string title = "")
    {
        ArgumentNullException.ThrowIfNull(title);
        Year = year;
        Day = day;
        Title = title;
    }

    /// <inheritdoc/>
    public abstract T Part1(ReadOnlySpan<char> span);

    /// <inheritdoc/>
    public abstract T Part2(ReadOnlySpan<char> span);
}