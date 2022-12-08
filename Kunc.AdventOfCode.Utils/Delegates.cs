namespace Kunc.AdventOfCode.Utils;

public delegate TResult ReadOnlySpanFunc<T, TResult>(ReadOnlySpan<T> span);
