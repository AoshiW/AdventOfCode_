namespace Kunc.AdventOfCode.Utils;

public ref struct SpanSliceEnumerator<T> where T : IEquatable<T>
{
    ReadOnlySpan<T> _span;
    readonly ReadOnlySpan<T> _sliceOfAny;
    readonly bool _skipEmpySlice;

    internal SpanSliceEnumerator(ReadOnlySpan<T> span, ReadOnlySpan<T> sliceOfAny, bool skipEmpySlice)
    {
        _span = span;
        _sliceOfAny = sliceOfAny;
        _skipEmpySlice = skipEmpySlice;
    }

    public SpanSliceEnumerator<T> GetEnumerator()
    {
        return this;
    }

    public ReadOnlySpan<T> Current { readonly get; private set; } = default;

    public bool MoveNext()
    {
        do
        {
            var i = _span.IndexOfAny(_sliceOfAny);
            if (i == -1)
            {
                Current = _span;
                _span = default;
            }
            else
            {
                Current = _span.Slice(0, i);
                _span = _span.Slice(i + 1);
            }
        } while (_skipEmpySlice && Current.IsEmpty && !_span.IsEmpty);
        return !Current.IsEmpty;
    }
}
